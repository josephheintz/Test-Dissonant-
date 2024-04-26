using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    AudioManager audioManager;
    // Start is called before the first frame update
    protected override void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        base.Start();
        rb.gravityScale = 12f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if(!isRecoiling && health > 0)
        {
            transform.position = Vector2.MoveTowards
                (transform.position, new Vector2(PlayerController.Instance.transform.position.x, transform.position.y),
                speed * Time.deltaTime);
        }
        if (health <= 0)
        {
            animator.SetBool("StillAlive", false);
            animator.SetTrigger("Fall");
            audioManager.PlayMSFX(audioManager.slimeDeath);
            StartCoroutine(DestroyAfterDelay());
        }
    }

    public override void EnemyHit(float _damageDone, Vector2 _hitDirection, float _hitForce)
    {
        base.EnemyHit(_damageDone, _hitDirection, _hitForce);
        animator.SetTrigger("TakeDamage");
        if (health > 0)
        {
            audioManager.PlayMSFX(audioManager.slimeTakeDamage);
        }
        else
        {
            audioManager.PlayMSFX(audioManager.slimeDeath);
        }
        
    }
    IEnumerator DestroyAfterDelay()
    {
        
        yield return new WaitForSecondsRealtime(1f); // Wait for 1 second after animation finishes
        Destroy(gameObject); // Destroy the game object
    }
}
