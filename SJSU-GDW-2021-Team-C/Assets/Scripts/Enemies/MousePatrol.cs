using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePatrol : MonoBehaviour
{
    public float speed;
    public float floorDetectRayDistance, wallDetectRayDistance;     //length of ray for mouse to detect floor 
    private bool movingRight;
    public Transform groundDetect;
    void Update()
    {
        transform.Translate(Time.deltaTime * speed * Vector2.right);
        RaycastHit2D groundCheck = Physics2D.Raycast(groundDetect.position, Vector2.down, floorDetectRayDistance);
        RaycastHit2D wallCheck = Physics2D.Raycast(transform.position, movingRight ? Vector2.left : Vector2.right, wallDetectRayDistance, 1>>0);

        Debug.DrawRay(transform.position, movingRight ? Vector2.left : Vector2.right, Color.black);

        if (groundCheck.collider == false || (wallCheck.collider == true && wallCheck.collider.gameObject != gameObject && wallCheck.collider.gameObject.transform.parent?.gameObject != gameObject))
        {
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = true;
            }
        }
    }
}