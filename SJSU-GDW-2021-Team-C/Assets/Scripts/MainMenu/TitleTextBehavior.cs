using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleTextBehavior : MonoBehaviour
{

    Vector2 startPos;
    public float bounceHeight = 6, bounceSpeed = 1.3f;


    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = startPos + new Vector2(0, bounceHeight * Mathf.Sin(Time.realtimeSinceStartup * bounceSpeed));

    }
}
