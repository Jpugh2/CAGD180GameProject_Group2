using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * [Maltz, Jeffrey]
 * [Date: 4/12/22]
 * [This script is for the lasers that will be used by both the enemies and the player]
 */
public class Laser : MonoBehaviour
{

   //Variables for the lasers
    [Header("Projectile Variables")]
    public float speed;
    public bool goingDown;

    // Update is called once per frame
    void Update()
    {
        //check for if lasers are going down, then transform down(for enemy)
        if (goingDown == true)
        {
            transform.position += speed * Vector3.down * Time.deltaTime;
        }
        //else check for if lasers travelling up, then transform up(for player)
        else
        {
            transform.position += speed * Vector3.up * Time.deltaTime;
        }
    }
}
