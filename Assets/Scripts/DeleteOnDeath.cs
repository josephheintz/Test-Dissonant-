using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnDeath : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<Health>().currentHealth <= 0){
            Debug.Log(gameObject.GetComponent<Health>().currentHealth);
            Destroy(gameObject);
        }
    }
}
