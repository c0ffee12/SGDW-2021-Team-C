using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChandelierPhysics : MonoBehaviour
{

    Transform t;
    public float speed = 1f, heightDegrees = 30f;


    // Start is called before the first frame update
    void Start()
    {
        t = this.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        t.rotation = Quaternion.Euler(0, 0, heightDegrees * Mathf.Sin(Time.realtimeSinceStartup * speed));
    }
}
