using System.Collections;
using UnityEngine;

public class SkeletonWeapon : MonoBehaviour
{
    public int attackDamage = 1;
    public float attackCooldown = 2f; // Adjust this value to control the attack cooldown
    private float nextAttackTime; // Time when the boss can attack again

    private BoxCollider2D boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        nextAttackTime = Time.time; // Initialize nextAttackTime to current time to allow immediate attack
    }

    public void Attack()
    {
        // Check if it's time for the boss to attack based on the cooldown
        if (Time.time >= nextAttackTime)
        {
            // Check if the BoxCollider2D component is not null
            if (boxCollider != null)
            {
                // Create an array to store all colliders within the BoxCollider2D bounds
                Collider2D[] colliders = Physics2D.OverlapBoxAll(boxCollider.bounds.center, boxCollider.bounds.size, 0f);

                // Loop through all colliders found within the BoxCollider2D bounds
                foreach (Collider2D collider in colliders)
                {
                    // Check if the collider belongs to the player
                    if (collider.CompareTag("Player"))
                    {
                        // Apply damage to the player
                        PlayerController.Instance.TakeDamage(attackDamage);
                    }
                }
            }

            // Set the next attack time to enforce the cooldown
            nextAttackTime = Time.time + attackCooldown;
        }
    }
}
