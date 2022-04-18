using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int speed = 15;

    private int health = 5;

    public Text healthtext;

    public Text gameOverText;

    public Text winText;

    public Text returnToTitleText;

    private Rigidbody rigid_body;

    public GameObject Player_laser_Prefab;

    public bool laser_Ready;                       // checks if cooldown is done

    public int Count = 0;

    public static int sceneNumber = 1;

    public Vector3 startPos;                       // starting position of the player
    // Start is called before the first frame update
    void Start()
    {
        laser_Ready = true;

        rigid_body = GetComponent<Rigidbody>();
        
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
        if (Input.GetKeyDown("space") && laser_Ready == true)
        {
            Instantiate(Player_laser_Prefab, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
            StartCoroutine(coolDown());

        }
    }

    // prevents player from spamming lasers by making them wait a couple seconds between firing
    IEnumerator coolDown()
    {
        laser_Ready = false;                                   // deactivate shooting

        yield return new WaitForSeconds(.5f);                   // wait half a seconds

        laser_Ready = true;                                    // reactivate shooting
    }

    private void healthPoints()
    {
        healthtext.text = "Health: " + health;
    }

    private void GameOver()
    {
        if (health <= 0)
        {
            Count = 0;
            gameOverText.text = "Game Over.";
            returnToTitleText.text = "Press Space to return to title screen";


            speed = 0;
            GetComponent<MeshRenderer>().enabled = false;
            if (Input.GetKeyDown("space"))                        // sends player back to title screen
            {
                gameOverText.text = "";                          // gets rid of gameOver text
                returnToTitleText.text = "";                     // gets rid of return text
                SceneManager.LoadScene(0);                          // Restarts back at starting screen
                health = 5;                                      // resets health
                Destroy(this.gameObject);                        // gets rid of old player object
                healthtext.text = "";                            // gets rid of old health text


            }

        }
    }

    private void Respawn()
    {
        transform.position = startPos;
        health--;
        if (health <= 0)
        {
            GameOver();
            //gameOverText.text = "Game Over!";
        }

    }

    public void WinGame()
    {
        if (Count == 10)
        {

            speed = 0;
            GetComponent<MeshRenderer>().enabled = false;
            winText.text = "You win!!";                          // reveals win text
            returnToTitleText.text = "Press Space to return to title screen";
            if (Input.GetKeyDown("space"))                       // sends player back to title screen
            {
                winText.text = "";                               // gets rid of win text   
                returnToTitleText.text = "";                     // gets rid of return to title text
                health = 5;                                      // resets health
                healthtext.text = "";                            // gets rid of old health text
                SceneManager.LoadScene(0);                       // Restarts back at starting screen
                Count = 0;                                       // resets count
                sceneNumber = 0;                                 // resets scene number
                Destroy(this.gameObject);                        // gets rid of old player object
                GameObject.Find("Canvas").GetComponent<SceneTransition>().redoCheck++;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyLaser")
        {
            Respawn();
        }
    }

    public void AllDead()
    {
        if (Count == 1)
        {
            SceneManager.LoadScene(sceneNumber += 1);            // if player has 2 kills, move onto lvl 2
        }
        if (Count == 3)                                         // if six, move to lvl 3
        {
            SceneManager.LoadScene(sceneNumber += 1);
        }
        if (Count == 6)                                         // if 12 move onto lvl 4
        {
            SceneManager.LoadScene(sceneNumber += 1);
        }
    }
}



