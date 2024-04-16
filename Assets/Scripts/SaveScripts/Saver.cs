using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Detect player tag on player
        if (other.CompareTag("Player"))
        {
            ///PersistenceDataManager.instance.NewGame();
            PersistenceDataManager.instance.SaveGame();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Detect player leaving trigger area

        if (other.CompareTag("Player"))
        {
            //Debug.Log("Good bye budy");
        }
    }
}
