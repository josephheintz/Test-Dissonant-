using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mob : MonoBehaviour
{
    public bool isFlipped = false;

    // Update is called once per frame
    void Update()
    {
        // Find the player dynamically during runtime
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        // Check if the player object is found
        if (playerObject != null)
        {
            // Get the player's Transform component
            Transform player = playerObject.transform;

            // Call the method to make the mob face the player
            LookAtPlayer(player);
        }
    }

    public void LookAtPlayer(Transform player)
    {
        if (player == null)
            return;

        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
}
