using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringTailPhysics : MonoBehaviour
{

    public GameObject springTail, catBody;
    public bool isGrounded;
    private float targetYScale;

    private float springiness = 0.4f;
    private float force, velocity;

    private void Start()
    {
        springTail = transform.Find("SpringTail").gameObject;
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

        springTail.transform.localScale = scale;
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

}
