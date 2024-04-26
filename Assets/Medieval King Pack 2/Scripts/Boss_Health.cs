using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : Enemy
{
    AudioManager audioManager;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        rb.gravityScale = 12f;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (health <= 0)
        {
            animator.SetBool("StillAlive", false);
            animator.SetTrigger("Fall");
            audioManager.PlayMSFX(audioManager.fantasyBossDeath);
            StartCoroutine(DestroyAfterDelay());
        }
    }

    public override void EnemyHit(float _damageDone, Vector2 _hitDirection, float _hitForce)
    {
        base.EnemyHit(_damageDone, _hitDirection, _hitForce);
        
        animator.SetTrigger("TakeDamage");
        audioManager.PlayMSFX(audioManager.fantasyBossDamage);
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSecondsRealtime(2f); // Wait for 2 second after animation finishes
        Destroy(gameObject); // Destroy the game object
    }
}