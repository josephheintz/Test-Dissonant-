using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] public int DamageAmount = 1;

    private void OnTriggerEnter2D(Collider2D other){
            // Detect hit tag on target
            Debug.Log("Hello");
                if(other.GetComponent<Health>() != null){
                    other.GetComponent<Health>().currentHealth = other.GetComponent<Health>().currentHealth - DamageAmount;
                } else {
                }
            }
        }
