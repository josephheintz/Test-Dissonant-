using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionNote : MonoBehaviour
{
    [SerializeField] GameObject noteText; // Expose noteText in the Unity Inspector
    public bool on = false;

    void Update()
    {
        if (on == true)
        {
            noteText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            noteText.SetActive(false);
            on = false;
        }
    }

}