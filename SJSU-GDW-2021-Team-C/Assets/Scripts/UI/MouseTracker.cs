using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracker : MonoBehaviour
{
    RectTransform r;
    GameObject player;

    void Start()
    {
        r = GetComponent<RectTransform>();
        player = GameObject.Find("Player");

        StartCoroutine(UpdateMouseTracker());

    }


    public IEnumerator UpdateMouseTracker()
    {
        GameObject nearestMouse;
        float nearestDistance;

        float rotationOfCursor;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("MouseHurtbox");

        GameObject door = GameObject.FindGameObjectWithTag("Door1");
        GameObject key = GameObject.FindGameObjectWithTag("Key1");

        if (enemies.Length > 1)
        {
             nearestMouse = enemies[0];
             nearestDistance = ((Vector2)(player.transform.position - enemies[0].transform.position)).sqrMagnitude;

            for(int i = 1; i < enemies.Length; i++)
            {
                float nextDist = ((Vector2)(player.transform.position - enemies[i].transform.position)).sqrMagnitude;
                if (nextDist < nearestDistance)
                {
                    nearestDistance = nextDist;
                    nearestMouse = enemies[i];
                }
            }



            rotationOfCursor = Vector2.SignedAngle(Vector2.up, nearestMouse.transform.position - player.transform.position + 2 * Vector3.up); //180 is temp; change when making new ui

        } 



        else if(key != null)
        {
            Debug.Log("1");
            rotationOfCursor = Vector2.SignedAngle(Vector2.up, key.transform.position - player.transform.position + 2 * Vector3.up) + 180;
        }
        
        else if(door != null)
        {
            Debug.Log("2");
            rotationOfCursor = Vector2.SignedAngle(Vector2.up, door.transform.position - player.transform.position + 2 * Vector3.up) + 180;
        }
        
        else
        {
            Debug.Log("3");
            rotationOfCursor = 0f;
        }
        r.rotation = Quaternion.Euler(0, 0, rotationOfCursor);

        yield return new WaitForSeconds(0.1f);
        StartCoroutine(UpdateMouseTracker());



    }
}
