using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePatrol : MonoBehaviour
{
    public float speed;
    public float floorDetectRayDistance;     //length of ray for mouse to detect floor 
    private bool movingRight;
    public Transform groundDetect;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundCheck = Physics2D.Raycast(groundDetect.position, Vector2.down, floorDetectRayDistance);
        if (groundCheck.collider == false)
        {
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}