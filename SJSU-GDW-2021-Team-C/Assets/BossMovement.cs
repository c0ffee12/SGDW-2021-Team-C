using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float speed;
    public float playerDetectDistance;     //length of ray for mouse to detect floor 
    public float wallDetectRayDistance;
    public float floorDetectRayDistance;
    public float minAggroRange;
    private bool movingRight;
    private bool jumping;
    public Transform groundDetect;
    public Transform player;
    private Rigidbody2D rb;
    private bool panicModeOn;

    public Animator animator;

    void Start()
    {
        panicModeOn = false;
        player = GameObject.Find("Player").gameObject.transform;
        animator = GetComponent<Animator>();
        animator.SetTrigger("Jump");
        rb = GetComponent<Rigidbody2D>();
        jumping = false;
        speed = 2;
    }
    void Update()
    {
        if (!panicModeOn)
        {
            speed = 2;
            ChasePlayer();
        }
        else
        {
            PanicRun();
        }
    }
    void FixedUpdate()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (!jumping)
        {
            jumping = true;
            StartCoroutine(Pounce());
        }
    }
    private void ChasePlayer()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (Mathf.Abs(transform.position.x - player.position.x) < minAggroRange)
        {
            transform.Translate(Time.deltaTime * speed * Vector2.right);
        }
        else if (transform.position.x < player.position.x)
        {
            transform.Translate(Time.deltaTime * speed * Vector2.right);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.Translate(Time.deltaTime * speed * Vector2.right);
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
    }

    private IEnumerator Pounce()
    {
        rb.AddForce(Vector2.up * 500);
        animator.SetTrigger("Jump");
        yield return new WaitForSeconds(2f);
        jumping = false;
    }
    private IEnumerator PanicModeDelay()
    {
        yield return new WaitForSeconds(5f);
        panicModeOn = false;
    }
    public void PanicMode()
    {
        panicModeOn = true;
        speed = 10;
        StartCoroutine(PanicModeDelay());
    }
    public void PanicRun()
    {
        transform.Translate(Time.deltaTime * speed * Vector2.right);
        RaycastHit2D groundCheck = Physics2D.Raycast(groundDetect.position, Vector2.down, floorDetectRayDistance);
        RaycastHit2D wallCheck = Physics2D.Raycast(transform.position, movingRight ? Vector2.left : Vector2.right, wallDetectRayDistance, 1 >> 0);

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
