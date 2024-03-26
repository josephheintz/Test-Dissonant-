using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NexisButtonController : MonoBehaviour
{
    private Vector2 landing; // Where the player will appear on the next map
    private GameObject player; // Prefab of the player object

    private void Start(){
          player = GameObject.FindGameObjectWithTag("Player");
    }

    public void NexJumpLandY(int landY)
    {
        landing.y = landY;
    }

    public void NexJumpLandX(int landX)
    {
        landing.x = landX;
    }

    public void NexJump(int scene)
    {
        //landing = new Vector2(0, 4);
        player.transform.position = landing;
        SceneManager.LoadScene(scene);
    }

}
