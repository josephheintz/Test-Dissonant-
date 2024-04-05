using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunderstrike : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float hitForce;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.tag == "Enemy")
        {
            _other.GetComponent<Enemy>().EnemyHit(damage, (_other.transform.position - transform.position).normalized, -hitForce);
        }
    }
}
