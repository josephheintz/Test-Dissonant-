using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected float recoilLength;
    [SerializeField] protected float recoilFactor;
    [SerializeField] protected bool isRecoiling = false;

    [SerializeField] protected PlayerController player;
    [SerializeField] protected float speed;

    [SerializeField] protected float damage;

    protected float recoilTimer;
    protected Rigidbody2D rb;
    protected Animator animator;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = PlayerController.Instance;
        animator = GetComponent<Animator>();
        animator.SetBool("StillAlive", true);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (health <= 0)
        {
            animator.SetBool("StillAlive", false);
            animator.SetTrigger("Fall");
            StartCoroutine(DestroyAfterDelay());
        }

        if (isRecoiling)
        {
            if(recoilTimer >= recoilLength)
            {
                recoilTimer += Time.deltaTime;
            }
            else
            {
                isRecoiling = false;
                recoilTimer = 0;
            }
        } 
    }
    public virtual void EnemyHit(float _damageDone, Vector2 _hitDirection, float _hitForce)
    {
        health -= _damageDone;
        if(!isRecoiling)
        {
            rb.AddForce(-_hitForce * recoilFactor * _hitDirection);
        }
    }

    protected void OnTriggerStay2D(Collider2D _other)
    {
        if(_other.CompareTag("Player") && !PlayerController.Instance.pState.invincible)
        {
            Attack();
            // PlayerController.Instance.HitStopTime(0, 5, 0.5f);
        }
    }

    protected virtual void Attack()
    {
        PlayerController.Instance.TakeDamage(damage);   
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSecondsRealtime(2f); // Wait for 2 second after animation finishes
        Destroy(gameObject); // Destroy the game object
    }
}
