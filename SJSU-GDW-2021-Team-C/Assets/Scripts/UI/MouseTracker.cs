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

        if(enemies.Length > 0)
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
            Debug.Log("Nearest Mouse: " + nearestMouse.transform.parent.name);



            rotationOfCursor = Vector2.SignedAngle(Vector2.up, nearestMouse.transform.position - player.transform.position + 2 * Vector3.up) + 180; //180 is temp; change when making new ui

        } else
        {
            rotationOfCursor = 0f;
        }
        r.rotation = Quaternion.Euler(0, 0, rotationOfCursor);

        yield return new WaitForSeconds(0.1f);
        StartCoroutine(UpdateMouseTracker());



    }
}
