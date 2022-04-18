using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * [Maltz, Jeffrey]
 * [4/11/22]
 * [This code is for enemies in our game]
 */

public class Enemy : MonoBehaviour
{
    public float speed;
    private Vector3 leftPos;
    private Vector3 rightPos;
    public GameObject leftPoint;
    public GameObject rightPoint;
    private bool goingLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        leftPos = leftPoint.transform.position;
        rightPos = rightPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

   //Function for enemy to move like a sentry
    private void Move()
    {
        //if moving left, check boundary, not moving left, add left vector
        if (goingLeft)
        {
            if (transform.position.x <= leftPos.x)
            {
                goingLeft = false;
            }
            else
            {
                transform.position += Vector3.left * Time.deltaTime * speed;
            }
        }
        //else, moving right check boundary, not reach boundary add right vector
        else
        {
            if (transform.position.x >= rightPos.x)
            {
                goingLeft = true;
            }
            else
            {
                transform.position += Vector3.right * Time.deltaTime * speed;
            }
        }
    }

    //If enemy gets hit by player laser, then enemy gets despawned
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Laser")
        {
            Destroy(this.gameObject);
            enemyCount--;
        }
    }
}
