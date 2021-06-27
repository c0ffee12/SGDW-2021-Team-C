using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabidMovement : MonoBehaviour
{
    public float speed;
    public float playerDetectDistance;     //length of ray for mouse to detect floor 
    public float floorDetectRayDistance;
    public float minAggroRange;
    private bool movingRight;
    private bool jumping;
    public Transform groundDetect;
    public Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumping = false;
    }
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer < playerDetectDistance)
        {
            if(Mathf.Abs(transform.position.x - player.position.x)<minAggroRange)
            {
                //do nothing
            }
            else {
                speed = 4;
                ChasePlayer();
            }
        }
        else
        {
            speed = 1;
            Patrol();    
        }
    }
    void FixedUpdate()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (!jumping)
        {
            if (distToPlayer > 4 && distToPlayer < playerDetectDistance)
            {
                jumping = true;
                StartCoroutine(Pounce());
            }
        }
    }
    private void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
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
    private IEnumerator Pounce()
    {
        rb.AddForce(Vector2.up * 500);
        yield return new WaitForSeconds(3f);
        jumping = false;
    }
}
