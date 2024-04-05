using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    public int health = 10;

    private CapsuleCollider2D capsuleCollider;

    public GameObject deathEffect;

    public bool isInvulnerable = false;

    private Animator animator;

    private void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    public void TakeDamage()
    {
        // Check if the CapsuleCollider2D component is not null
        if (capsuleCollider != null)
        {
            // Create an array to store all colliders within the BoxCollider2D bounds
            Collider2D[] colliders = Physics2D.OverlapBoxAll(capsuleCollider.bounds.center, capsuleCollider.bounds.size, 0f);

            // Loop through all colliders found within the BoxCollider2D bounds
            foreach (Collider2D collider in colliders)
            {
                // Check if the collider belongs to the player
                if (collider.CompareTag("Player"))
                {
                    // Apply damage to the player
                    health -= 1;
                    animator = GetComponent<Animator>();
                    animator.SetTrigger("TakeDamage");
                }
            }
            if (health <= 0)
            {
                Die();
            }
        }

    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}