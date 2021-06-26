using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabidMovement : MonoBehaviour
{
    public float speed;
    public float playerDetectDistance;     //length of ray for mouse to detect floor 
    public float floorDetectRayDistance;
    private bool movingRight;
    public Transform groundDetect;
    public Transform player;

    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if(distToPlayer < playerDetectDistance)
        {
            speed = 4;
            ChasePlayer();
        }
        else
        {
            speed = 1;
            Patrol();    
        }
    }
    private void ChasePlayer()
    {
        if (transform.position.x < player.position.x + 0.2f)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else   
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
    }
    private void Patrol()
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
