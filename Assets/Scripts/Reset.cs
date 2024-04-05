using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    [SerializeField] public float resetX;

    public void OnTriggerEnter2D(Collider2D other){
        Vector2 currentPosition = other.transform.position;
        Vector2 newPosition = new Vector3(resetX, currentPosition.y);
        other.transform.position = newPosition;

    }
}
