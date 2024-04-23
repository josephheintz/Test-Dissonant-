using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    [SerializeField] private RawImage blackOut; // Change this to RawImage type
    [SerializeField] private GameObject blackOutCanvas; // Reference to the Canvas or the parent GameObject of RawImage
    AudioManager audioManager;


    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        blackOutCanvas.SetActive(true);
        StartCoroutine(FadeInCoroutine());
    }

    IEnumerator FadeInCoroutine()
    {
        audioManager.PlaySFX(audioManager.portalIn);
        Color color = blackOut.color;
        while (color.a > 0)
        {
            color.a -= Time.deltaTime * 0.5f; // Adjust the speed of fade
            blackOut.color = color;
            yield return null;
        }
        blackOutCanvas.SetActive(false);
    }
}
