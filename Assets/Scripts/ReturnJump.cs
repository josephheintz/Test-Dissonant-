using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnJump : MonoBehaviour
{
    private Vector2 landing = new Vector2(0, 4); // Where the player will appear on the next map
    private GameObject playerPrefab; // Prefab of the player object

    public void Start()
    {
        Jump();
    }

    public static void Jump()
    {
        GameObject playerPrefab = GameObject.FindGameObjectWithTag("Player");
        SceneManager.LoadScene(1);
        playerPrefab.transform.position = new Vector2(0, 2);
    }

}
