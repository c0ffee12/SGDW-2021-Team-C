using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringTailPhysics : MonoBehaviour
{

    public Rigidbody catRB;
    private GameObject springTail, hitbox;
    public bool isGrounded
    {
        get;
        private set;
    }

    [Range(0, 5)]
    public float targetYScale;

    [Range(0, 30)]
    public float springiness = 5f;

    [Range(0, 80)]
    public float stiffness = 0f;

    public float force, velocity;

    private void Start()
    {
        catRB = GetComponent<Rigidbody>();
        springTail = transform.Find("SpringTail/SpringTailHitbox/SpringTailPivot").gameObject;
        hitbox = transform.Find("SpringTail/SpringTailHitbox").gameObject;
        targetYScale = springTail.transform.localScale.y;

        //initial starting physics
        force = 0f;
        velocity = -0.3f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //assign force based on distance to Y scale, like physics F = -kx
        //k is springiness
        force = springiness * (springTail.transform.localScale.y - targetYScale);

        //spring dampener
        force += stiffness * velocity * Time.deltaTime;


        velocity -= force;
        Vector2 scale = springTail.transform.localScale;

        //change scale based on velocity
        scale.y += velocity * Time.deltaTime;
        scale.y = Mathf.Clamp(scale.y, 0.2f, 5);

        springTail.transform.localScale = scale;

    }

    public void SetTargetLength(float targetLen)
    {
        targetYScale = targetLen;
    }

    public void SetSpringiness(float springiness)
    {
        this.springiness = springiness;
    }

    public void SetStiffness(float stiffness)
    {
        this.stiffness = stiffness;
    }
   

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log(collision.otherCollider + ": " + Vector3.Dot(Vector3.down, collision.contacts[0].normal));

        if (collision.enabled &&  Vector3.Dot(Vector3.down, collision.contacts[0].normal) < -0.5f && collision.otherCollider.gameObject == hitbox)
        {

            isGrounded = true;

        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.otherCollider.gameObject == hitbox  && collision.contacts.Length == 0)
        {
            isGrounded = false;
        }
    }

}
