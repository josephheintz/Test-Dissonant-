using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnJump : MonoBehaviour
{
    [SerializeField] public Vector2 landing; // Where the player will appear on the next map

    private void OnTriggerEnter2D(Collider2D other){

            // Detect player tag on player
            if(other.tag == "Player"){
                SceneManager.LoadScene(1);
                other.transform.position = landing;
            }
        }

}
