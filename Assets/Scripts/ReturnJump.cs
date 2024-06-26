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
    private static GameObject healthUI; // the Managers system
    private bool victory = true;

    public void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager");
        healthUI = GameObject.FindGameObjectWithTag("HealthUI");
        levelManager.GetComponent<TeleportTracker>().telea[TelaIndex] = true;
        for(int i = 0; i < levelManager.GetComponent<TeleportTracker>().bosses.Length; i++){
            if(levelManager.GetComponent<TeleportTracker>().bosses[i] != true) victory = false;
        }
        if(victory == true) SceneManager.LoadScene(24);
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
        player.GetComponent<PlayerController>().health = player.GetComponent<PlayerController>().maxHealth;
        if(healthUI != null) healthUI.GetComponent<HeartController>().SetFilledHearts();
        SceneManager.LoadScene(1);
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.transform.position = new Vector2(15, 2);
    }

    public static void JumpToStart()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        SceneManager.LoadScene(3);
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.transform.position = new Vector2(-45, -2);
    }

}
