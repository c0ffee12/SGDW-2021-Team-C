using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabidMovement : MonoBehaviour
{
    public float speed;
    public float playerDetectDistance;     //length of ray for mouse to detect floor 
    public Transform groundDetect;
    public Transform player;

    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if(distToPlayer < playerDetectDistance)
        {
            chasePlayer();
        }
            //mouse will stop if player not detected
    }
    private void chasePlayer()
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
}
