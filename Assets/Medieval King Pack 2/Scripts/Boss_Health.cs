using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : Enemy
{

    private CapsuleCollider2D capsuleCollider;

    public bool isInvulnerable = false;

    private Animator animator;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        rb.gravityScale = 12f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

    }

    public override void EnemyHit(float _damageDone, Vector2 _hitDirection, float _hitForce)
    {
        base.EnemyHit(_damageDone, _hitDirection, _hitForce);
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}