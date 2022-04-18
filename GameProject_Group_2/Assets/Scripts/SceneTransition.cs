using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public GameObject player;
    public static SceneTransition instance;

    public int sceneChecker = 0;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;


        if (sceneChecker < 4)                   // while the game is still going on, don't destroy these objects
        {
            DontDestroyOnLoad(player);
            DontDestroyOnLoad(this.gameObject);
        }




    }

    public void FixedUpdate()
    {
        if (sceneChecker >= 4)                    // if the game has ended, destroy the objects to prepare for a reset
        {
            Destroy(this.gameObject);
            Destroy(GameObject.Find("Player"));
            sceneChecker = 0;
        }
    }

    public void SceneJump(int sceneNumber)
    {
        SceneManager.LoadSceneAsync(sceneNumber); // loads scene of whatever number it calls) 
    }
}
