using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnJump : MonoBehaviour
{
    [SerializeField] private Vector2 landing; // Where the player will appear on the next map
    [SerializeField] private GameObject playerPrefab; // Prefab of the player object

    private void Start()
    {
        SceneManager.LoadScene(1);
        playerPrefab.transform.position = landing;

    }
}

