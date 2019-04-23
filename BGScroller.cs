using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{

    public float scrollSpeed;
    public float tileSizedZ;
    public GameController gc;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;

    }


    void Update()
    {
        float newPosition;

        if (gc.checker != 1)
        {
            newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizedZ);
            transform.position = startPosition + Vector3.forward * newPosition;
        }
        else
        {


            newPosition = Mathf.Repeat(Time.time * (scrollSpeed * 50), tileSizedZ);

            transform.position = startPosition + Vector3.forward * newPosition;

           
        }
    }
}




