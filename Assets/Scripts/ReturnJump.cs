using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnJump : MonoBehaviour
{

    [SerializeField] private RawImage blackOut; // Change this to RawImage type
    private Vector2 landing = new Vector2(0, 4); // Where the player will appear on the next map
    private GameObject playerPrefab; // Prefab of the player object

    public void Start()
    {
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
        GameObject playerPrefab = GameObject.FindGameObjectWithTag("Player");
        SceneManager.LoadScene(1);
        playerPrefab.transform.position = new Vector2(0, 2);
    }

}
