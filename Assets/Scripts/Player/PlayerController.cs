using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Horizontal Movement Settings:")]
    [SerializeField] private float walkSpeed = 1; //Sets player's movement speed
    [Space(5)]


    [Header("Vertical Movement Settings:")]
    [SerializeField] private float jumpForce = 45f; //How high the player jumps

    private int jumpBufferCounter = 0; //Stores the number of frames the player can buffer a jump
    [SerializeField] private int jumpBufferFrames; //Max amount of frames the player can buffer a jump

    private float coyoteTimeCounter = 0; //Stores the isGrounded() bool
    [SerializeField] private float coyoteTime; //Max amount of time/frames the player can jump after leaving the ground

    private int airJumpCounter = 0; //Keeps track of how many air jumps the player has done
    [SerializeField] private int maxAirJumps; //Max amount of air jumps

    private float gravity; //Stores the gravity scale of the player at start
    [Space(5)]


    [Header("Ground Check Settings:")]
    [SerializeField] private Transform groundCheckPoint; //Point at which ground is checked
    [SerializeField] private float groundCheckY = 0.2f; //Distance from the center of the player to the bottom of the ground 
    [SerializeField] private float groundCheckX = 0.5f; //Distance from the center of the player to the edge of the ground CP
    [SerializeField] private LayerMask whatIsGround; //Sets the ground layer
    [Space(5)]


    [Header("Dash Settings:")]
    [SerializeField] private float dashSpeed; //Speed of the dash
    [SerializeField] private float dashTime; //Amount of time dashing
    [SerializeField] private float dashCooldown; //Amount of time between dashes (cooldown)
    private bool dashCheck = true, dashed;
    [Space(5)]


    [Header("Attack Settings:")]
    [SerializeField] private Transform SideAttackTransform; //The middle of the attack area
    [SerializeField] private Vector2 SideAttackArea; //The size of the attack area

    [SerializeField] private Transform UpAttackTransform;
    [SerializeField] private Vector2 UpAttackArea;

    [SerializeField] private Transform DownAttackTransform;
    [SerializeField] private Vector2 DownAttackArea;

    [SerializeField] private LayerMask attackableLayer; //The layer the player can attack and recoil off of

    private float timeBetweenAttack, timeSinceAttack;

    [SerializeField] private float damage; //Damage player does to an enemy

    [SerializeField] private GameObject slashEffect; //Effect of the slash

    bool restoreTime;
    float restoreTimeSpeed;
    [Space(5)]


    [Header("Recoil Settings:")]
    [SerializeField] private int recoilXSteps = 5; //How many FixedUpdates() the player recoils horizontally for
    [SerializeField] private int recoilYSteps = 5; //How many FixedUpdates() the player recoils horizontally for

    [SerializeField] private float recoilXSpeed = 100; //Speed of horizontal recoil
    [SerializeField] private float recoilYSpeed = 100; //Speed of vertical recoil

    private int stepsXRecoiled, stepsYRecoiled; //Number of steps recoiled horizontally and vertically
    [Space(5)]


    [Header("Health Settings:")]
    public int health; //Player's current health
    public int maxHealth; //Player's max health
    [SerializeField] float hitFlashSpeed;
    public delegate void OnHealthChangedDelegate();
    [HideInInspector] public OnHealthChangedDelegate onHealthChangedCallback;

    float healTimer;
    [SerializeField] float timeToHeal;
    [Space(5)]

    [Header("Ability Settings:")]
    [SerializeField] public bool canDash;
    [SerializeField] public bool canDoubleJump;
    [Space(5)]

    [Header("Mana Settings:")]
    [SerializeField] Image manaStorage;

    [SerializeField] float mana;
    [SerializeField] float manaDrainSpeed;
    [SerializeField] float manaGain;
    [Space(5)]

    [Header("Spell Settings:")]
    //Spell stats
    [SerializeField] float manaSpellCost = 0.3f;
    [SerializeField] float timeBetweenCast = 0.5f;
    float timeSinceCast;
    [SerializeField] float spellDamage; //Thunderstrike damage

    //Spell cast game objects
    [SerializeField] GameObject downSpellThunderstrike;
    [Space(5)]


    [HideInInspector] public PlayerStateList pState;
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sr;


    //Input Variables
    private float xAxis, yAxis;
    private bool attacking = false;


    public static PlayerController Instance;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        Health = maxHealth;

        DontDestroyOnLoad(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        pState = GetComponent<PlayerStateList>();

        rb = GetComponent<Rigidbody2D>();

        sr = GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();

        gravity = rb.gravityScale;

        Mana = mana;
        manaStorage.fillAmount = Mana;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(SideAttackTransform.position, SideAttackArea);
        Gizmos.DrawWireCube(UpAttackTransform.position, UpAttackArea);
        Gizmos.DrawWireCube(DownAttackTransform.position, DownAttackArea);
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        UpdateJumpVar();

        if (pState.dashing) return;
        Flip();
        Move();
        Jump();
        StartDash();
        Attack();
        RestoreTimeScale();
        FlashWhileInvincible();
        Heal();
        CastSpell();
    }

    private void OnTriggerEnter2D(Collider2D _other) //For the thunderstrike spell
    {
        if (_other.GetComponent<Enemy>() != null && pState.casting)
        {
            _other.GetComponent<Enemy>().EnemyHit(spellDamage, (_other.transform.position - transform.position).normalized, -recoilYSpeed);
        }
    }

    private void FixedUpdate()
    {
        if (pState.dashing) return;
        Recoil();
    }

    void GetInput()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");
        attacking = Input.GetButtonDown("Attack");
    }

    void Flip()
    {
        if (xAxis < 0)
        {
            transform.localScale = new Vector2(-4, transform.localScale.y);
            pState.lookingRight = false;
        }
        else if (xAxis > 0)
        {
            transform.localScale = new Vector2(4, transform.localScale.y);
            pState.lookingRight = true;
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(xAxis * walkSpeed, rb.velocity.y);
        anim.SetBool("Running", rb.velocity.x != 0 && IsGrounded());
    }

    void StartDash()
    {
        if (dashCheck && Input.GetButtonDown("Dash") && !dashed && canDash)
        {
            StartCoroutine(Dash());
            dashed = true;
        }

        if (IsGrounded())
        {
            dashed = false;
        }
    }

    IEnumerator Dash()
    {
        dashCheck = false;
        pState.dashing = true;
        anim.SetTrigger("Dashing");
        rb.gravityScale = 0;
        int _dir = pState.lookingRight ? 1 : -1;
        rb.velocity = new Vector2(_dir * dashSpeed, 0);
        yield return new WaitForSeconds(dashTime);
        rb.gravityScale = gravity;
        pState.dashing = false;
        yield return new WaitForSeconds(dashCooldown);
        dashCheck = true;
    }

    void Attack()
    {
        timeSinceAttack += Time.deltaTime;
        if (attacking && timeSinceAttack >= timeBetweenAttack)
        {
            timeSinceAttack = 0;
            anim.SetTrigger("Attacking");

            if (yAxis == 0 || yAxis < 0 && IsGrounded())
            {
                Hit(SideAttackTransform, SideAttackArea, ref pState.recoilingX, recoilXSpeed);
                Instantiate(slashEffect, SideAttackTransform);
                
            }
            else if (yAxis > 0)
            {
                Hit(UpAttackTransform, UpAttackArea, ref pState.recoilingY, recoilYSpeed);
                SlashEffectAngle(slashEffect, 90, UpAttackTransform);
            }
            else if (yAxis < 0 && !IsGrounded())
            {
                Hit(DownAttackTransform, DownAttackArea, ref pState.recoilingY, recoilYSpeed);
                SlashEffectAngle(slashEffect, -90, DownAttackTransform);
            }
        }
    }

    void Hit(Transform _attackTransform, Vector2 _attackArea, ref bool _recoilDir, float _recoilStrength)
    {
        Collider2D[] objectsToHit = Physics2D.OverlapBoxAll(_attackTransform.position, _attackArea, 0, attackableLayer);
        List<Enemy> enemiesHit = new();

        if (objectsToHit.Length > 0)
        {
            _recoilDir = true;
        }
        for (int i = 0; i < objectsToHit.Length; i++)
        {
            Enemy e = objectsToHit[i].GetComponent<Enemy>();
            if (e && !enemiesHit.Contains(e))
            {
                e.EnemyHit(damage, (transform.position - objectsToHit[i].transform.position).normalized, _recoilStrength);
                enemiesHit.Add(e);

                //Gain mana on enemy hit
                Mana += manaGain;
            }
        }
    }

    void SlashEffectAngle(GameObject _slashEffect, int _effectAngle, Transform _attackTransform)
    {
        _slashEffect = Instantiate(_slashEffect, _attackTransform);
        _slashEffect.transform.localEulerAngles = new Vector3(0, 0, _effectAngle);
        // _slashEffect.transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
    }

    void Recoil()
    {
        if(pState.recoilingX)
        {
            if(pState.lookingRight)
            {
                rb.velocity= new Vector2(-recoilXSpeed, 0);
            }
            else
            {
                rb.velocity = new Vector2(recoilXSpeed, 0);
            }
        }

        if(pState.recoilingY)
        {
            rb.gravityScale = 0;
            if (yAxis < 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, recoilYSpeed);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, -recoilYSpeed);
            }
            airJumpCounter = 0;
        }
        else
        {
            rb.gravityScale = gravity;
        }

        //Stop recoil
        if(pState.recoilingX & stepsXRecoiled < recoilXSteps)
        {
            stepsXRecoiled++;
        }
        else
        {
            StopRecoilX();
        }
        if (pState.recoilingY && stepsYRecoiled < recoilYSteps)
        {
            stepsYRecoiled++;
        }
        else
        {
            StopRecoilY();
        }

        if(IsGrounded())
        {
            StopRecoilY();
        }
    }

    void StopRecoilX()
    {
        stepsXRecoiled = 0;
        pState.recoilingX = false;
    }

    void StopRecoilY()
    {
        stepsYRecoiled = 0;
        pState.recoilingY = false;
    }

    public void TakeDamage(float _damage)
    {
        Health -= Mathf.RoundToInt(_damage);
        StartCoroutine(StopTakingDamage());
    }

    IEnumerator StopTakingDamage()
    {
        pState.invincible = true;
        anim.SetTrigger("TakeDamage");
        yield return new WaitForSeconds(1f);
        pState.invincible = false;
    }

    void FlashWhileInvincible()
    {
        sr.material.color = pState.invincible ? 
            Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time * hitFlashSpeed, 1.0f)) : Color.white;
    }

    void RestoreTimeScale()
    {
        if (restoreTime)
        {
            if (Time.timeScale < 1)
            {
                Time.timeScale += Time.unscaledDeltaTime * restoreTimeSpeed;
            }
            else
            {
                Time.timeScale = 1;
                restoreTime = false;
            }
        }
    }

    public void HitStopTime(float _newTimeScale, int _restoreSpeed, float _delay)
    {
        restoreTimeSpeed = _restoreSpeed;
        Time.timeScale = _newTimeScale;

        if (_delay > 0)
        {
            StopCoroutine(StartTimeAgain(_delay));
            StartCoroutine(StartTimeAgain(_delay));
        }
        else
        {
            restoreTime = true;
        }
    }

    IEnumerator StartTimeAgain(float _delay)
    {
        yield return new WaitForSecondsRealtime(_delay);
        restoreTime = true;
    }

    public int Health
    {
        get { return health; }
        set
        {
            if(health != value)
            {
                health = Mathf.Clamp(value, 0, maxHealth);

                if (onHealthChangedCallback != null)
                {
                    onHealthChangedCallback.Invoke();
                }
            }
        }
    }

    void Heal()
    {
        if(Input.GetButton("Healing") && Health < maxHealth && Mana > 0 && !pState.jumping && !pState.dashing)
        {
            pState.healing = true;
            anim.SetBool("Healing", true);

            //Healing
            healTimer += Time.deltaTime;
            if (healTimer >= timeToHeal)
            {
                Health++;
                healTimer = 0;
            }

            //Draining mana
            Mana -= Time.deltaTime * manaDrainSpeed;
        }
        else
        {
            pState.healing = false;
            anim.SetBool("Healing", false);
            healTimer = 0;
        }
    }

    float Mana
    {
        get { return mana; }
        set
        {
            //If mana stats change
            if (mana != value)
            {
                mana = Mathf.Clamp(value, 0, 100);

                //Update mana bar
                manaStorage.fillAmount = Mana;
            }
        }
    }

    void CastSpell()
    {
        if (Input.GetButtonDown("CastSpell") && timeSinceCast >= timeBetweenCast && Mana >= manaSpellCost)
        {
            pState.casting = true;
            timeSinceCast = 0;
            StartCoroutine(CastCoroutine());
        }
        else
        {
            timeSinceCast += Time.deltaTime;
        }
    }

    IEnumerator CastCoroutine()
    {
        anim.SetBool("Casting", true);
        yield return new WaitForSeconds(0.5f);

        //Down cast
        if (yAxis < 0)
        {
            downSpellThunderstrike.SetActive(true);
        }

        Mana -= manaSpellCost;
        yield return new WaitForSeconds(0.85f);
        anim.SetBool("Casting", false);
        pState.casting = false;
        downSpellThunderstrike.SetActive(false);
    }

    public bool IsGrounded()
    {
        if (Physics2D.Raycast(groundCheckPoint.position, Vector2.down, groundCheckY, whatIsGround)
            || Physics2D.Raycast(groundCheckPoint.position + new Vector3(groundCheckX, 0, 0), Vector2.down, groundCheckY, whatIsGround)
            || Physics2D.Raycast(groundCheckPoint.position + new Vector3(-groundCheckX, 0, 0), Vector2.down, groundCheckY, whatIsGround))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Jump()
    {
        if (jumpBufferCounter > 0 && coyoteTimeCounter > 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce);

            pState.jumping = true;
        }
        if (!IsGrounded() && airJumpCounter < maxAirJumps && Input.GetButtonDown("Jump") && canDoubleJump)
        {
            pState.jumping = true;

            airJumpCounter++;

            rb.velocity = new Vector3(rb.velocity.x, jumpForce);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 3)
        {
            pState.jumping = false;

            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

        anim.SetBool("Jumping", !IsGrounded());
        anim.SetBool("Falling", rb.velocity.y < 0);
    }

    void UpdateJumpVar()
    {
        if (IsGrounded())
        {
            pState.jumping = false;
            coyoteTimeCounter = coyoteTime;
            airJumpCounter = 0;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferFrames;
        }
        else
        {
            jumpBufferCounter--;
        }

    }
}