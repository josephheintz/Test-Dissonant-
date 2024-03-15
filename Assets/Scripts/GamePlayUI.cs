using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import UnityEngine.UI to use Text compone

public class GamePlayUI : MonoBehaviour
{
    [SerializeField]  private GameObject player; // Prefab of the player object
    private Text healthText;

    void Start(){
        healthText = GetComponent<Text>();
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + player.GetComponent<Health>().currentHealth.ToString();
    }
}
