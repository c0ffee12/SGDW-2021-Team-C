using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabidMovement : MonoBehaviour
{
    public float speed;
    public float floorDetectRayDistance;     //length of ray for mouse to detect floor 
    public float playerDetectRayDistance;    //length of ray for mouse to detect player
    private bool movingRight;
    public Transform groundDetect;
    public Transform playerDetect;
    Rigidbody2D rb;
    private bool patrolOn;                   //determines if mouse is patrolling, otherwise following player

    void Start()
    {
        patrolOn = true;
    }
    void Update()
    {
        RaycastHit2D groundCheck = Physics2D.Raycast(groundDetect.position, Vector2.down, floorDetectRayDistance);
        if (patrolOn)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
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
    private void FixedUpdate()
    {
        RaycastHit2D playerCheck = Physics2D.Raycast(playerDetect.position, Vector2.right, playerDetectRayDistance);
        if (playerCheck.collider != null)
        {
            if (playerCheck.collider.CompareTag("Player"))
            {
                patrolOn = false;
                rb.AddForce(Vector2.up * 8);
            }
        }
        else
        {
            patrolOn = true;
        }
    }
}
