using UnityEngine;

public class Skeleton_Run : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackRange = 3f;
    public float attackCooldown = 4f; // Adjust this value to control the attack cooldown
    public float maxRange = 15f; // Maximum range for the mob's movement towards the enemy

    Transform player;
    Rigidbody2D rb;
    Boss boss;
    bool hasAttacked = false;
    float nextAttackTime; // Time when the boss can attack again
    AudioManager audioManager;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
        hasAttacked = false; // Reset the attack flag when entering the state
        // nextAttackTime = Time.time; // Initialize nextAttackTime to current time
        float distanceToPlayer = Vector2.Distance(rb.position, player.position);
        if (distanceToPlayer <= maxRange)
        {
            animator.SetBool("Prox", false);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        float distanceToPlayer = Vector2.Distance(rb.position, player.position);
        if (distanceToPlayer <= maxRange)
        {
            animator.SetBool("Prox", true);
            Vector2 target = new Vector2(player.position.x, rb.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);

            // Check if it's time for the boss to attack based on the cooldown
            if (!hasAttacked && Time.time >= nextAttackTime && Vector2.Distance(player.position, rb.position) <= attackRange)
            {
                animator.SetTrigger("Attack");
                hasAttacked = true; // Set the flag to true to prevent continuous attacks
                nextAttackTime = Time.time + attackCooldown; // Set the next attack time

            }
            // Update the nextAttackTime if the boss hasn't attacked yet
            if (hasAttacked)
            {
                audioManager.PlayMSFX(audioManager.skeletonAttack);
                nextAttackTime = Time.time + attackCooldown; // Set the next attack time
            }
        }
        else
        {
            animator.SetBool("Prox", false);
        }

       
    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Reset the attack flag when exiting the state
        hasAttacked = false;
        animator.ResetTrigger("Attack");
    }
}
