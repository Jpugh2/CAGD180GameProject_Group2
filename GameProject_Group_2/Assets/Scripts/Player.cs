using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int speed = 15;

    private int health = 5;

    public Text healthtext;

    private Rigidbody rigid_body;

    public GameObject Player_Bullet_Prefab;

    public bool bullet_Ready;                       // checks if cooldown is done

    // Start is called before the first frame update
    void Start()
    {
        bullet_Ready = true;

        rigid_body = GetComponent<Rigidbody>();

        Vector3 startPos;                          // starting position of the player

        startPos = transform.position;


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        move();                                     // movement control
        healthPoints();                             // display health points

    }

    private void move()
    {
        Vector3 temp;

        temp = transform.position;                  // checks for player position





        Vector3 add_position = Vector3.zero;

        if (Input.GetKey("a"))                      // move left
        {
            temp += Vector3.left * Time.deltaTime * speed;
        }
        if (Input.GetKey("d"))                      // move right
        {
            temp += Vector3.right * Time.deltaTime * speed;
        }
        transform.position = temp;  // changes the player position to the temporary one

        // Fire projectile if space is pressed
        if (Input.GetKeyDown("space") && bullet_Ready == true)
        {
            Instantiate(Player_Bullet_Prefab, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
            StartCoroutine(coolDown());

        }
    }

    // prevents player from spamming bullets by making them wait a couple seconds between firing
    IEnumerator coolDown()
    {
        bullet_Ready = false;                                   // deactivate shooting

        yield return new WaitForSeconds(2f);            // wait 2 seconds

        bullet_Ready = true;                                    // reactivate shooting
    }

    private void healthPoints()
    {
        healthtext.text = "Health: " + health;
        //Once player and enemy are finished, set up collision counters for health
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health--;
        }

    }
}



