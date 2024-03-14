using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpin : MonoBehaviour
{
    [SerializeField] public float speed = 50;
    private Vector3 move;
    private float xRand;
    private float yRand;
    private float zRand;


    // Start is called before the first frame update
    void Start()
    {
        xRand = Random.Range(0, 2f);
        yRand = Random.Range(0, 2f);
        zRand = Random.Range(0, 2f);
        move = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        move.x += (speed * Time.deltaTime * xRand);
        move.y += (speed * Time.deltaTime * yRand);
        move.z += (speed * Time.deltaTime * zRand);
        gameObject.transform.rotation = Quaternion.Euler(move);
    }
}
