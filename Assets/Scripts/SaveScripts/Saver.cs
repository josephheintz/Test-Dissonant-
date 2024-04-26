using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D other)
    {
        // Detect player tag on player
        if (other.CompareTag("Player"))
        {
            PersistenceDataManager.instance.SaveGame();
        }
    }
}
