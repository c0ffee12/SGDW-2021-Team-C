using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFloater : MonoBehaviour
{
    public float speed;
    private float maxHeight;
    private float minHeight;
    private bool movingUp;
    private void Start()
    {
        maxHeight = transform.position.y + 0.1f;
        minHeight = transform.position.y - 0.1f;
        movingUp = false;
    }
    void Update()
    {
        if(transform.position.y <= minHeight)
        {
            movingUp = true;
        }
        else if(transform.position.y >= maxHeight)
        {
            movingUp = false;
        }
        if (movingUp)
        {
            transform.Translate(Time.deltaTime * speed * Vector2.up);
        }
        else
        {
            transform.Translate(Time.deltaTime * speed * Vector2.down);
        }
    }
}
