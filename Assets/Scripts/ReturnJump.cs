using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnJump : MonoBehaviour
{

    [SerializeField] private RawImage blackOut; // Change this to RawImage type
    private Vector2 landing = new Vector2(0, 4); // Where the player will appear on the next map
    private GameObject player; // Prefab of the player object
    [SerializeField] public int TelaIndex; //
    private GameObject levelManager; // the Managers system

    public void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager");
        levelManager.GetComponent<TeleportTracker>().telea[TelaIndex] = true;
        StartCoroutine(Fade());
    }

    public IEnumerator Fade()
    {
        RawImage blackOutImage = blackOut.GetComponent<RawImage>();
        Color color = blackOutImage.color;

        while (color.a < 1)
        {
            color.a += Time.deltaTime * 0.5f; // Adjust the speed of fade
            blackOutImage.color = color;
            yield return null;
        }

        Jump();
    }

    public static void Jump()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        SceneManager.LoadScene(1);
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.transform.position = new Vector2(15, 2);
    }

    public static void JumpToStart()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        SceneManager.LoadScene(4);
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.transform.position = new Vector2(-45, -2);
    }

}
