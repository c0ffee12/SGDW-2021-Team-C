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
    private float targetYScale;

    [Range(0, 2)]
    public float springiness = 0.4f;
    private float force, velocity;

    private void Start()
    {
        catRB = GetComponent<Rigidbody>();
        springTail = transform.Find("SpringTail/SpringTailHitbox/SpringTailPivot").gameObject;
        targetYScale = springTail.transform.localScale.y;
        force = 0f;
        velocity = -0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        force = springiness * (springTail.transform.localScale.y - targetYScale);
        velocity -= force;
        Vector2 scale = springTail.transform.localScale;
        scale.y += velocity * Time.deltaTime;
        scale.y = Mathf.Clamp(scale.y, 0.2f, 2);

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
