using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringTailPhysics : MonoBehaviour
{

    public Rigidbody catRB;
    public GameObject springTail, catBody;
    public bool isGrounded
    {
        get;
        private set;
    }

    [Range(0, 5)]
    public float targetYScale;

    [Range(0, 30)]
    public float springiness = 0.4f;

    [Range(0, 80)]
    public float stiffness = 0f;

    private float force, velocity;

    private void Start()
    {
        catRB = GetComponent<Rigidbody>();
        springTail = transform.Find("SpringTail/SpringTailHitbox/SpringTailPivot").gameObject;
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

        //springTail.GetComponent<SpriteRenderer>().size = springTail.GetComponent<RectTransform>().rect.size;
    }

    public void SetTargetLength(float targetLen)
    {
        targetYScale = targetLen;
    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision:" + collision.gameObject.name);
        isGrounded = true;

        if (collision.gameObject == springTail)
        {

            isGrounded = true;

        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.contacts.Length == 0)
        {
            isGrounded = false;
        }
    }

}
