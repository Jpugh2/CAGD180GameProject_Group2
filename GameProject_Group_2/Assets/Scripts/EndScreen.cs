using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public static EndScreen start;

    public Text TitleText;

    private void Start()
    {
        TitleText.text = "Press space to play again!";
        start = this;
    }

    void Update()
    {
        GameGo();
    }

    public void Begin(int starter)
    {
        SceneManager.LoadScene(starter);   //loads scene of whatever number it calls                    
    }
    public void GameGo()
    {
        if (Input.GetKeyDown("space"))
        {
            TitleText.text = "";
            SceneManager.LoadScene(1);     // loads the first level upon pressing space 
        }
    }

}
