using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public void StartLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void StartLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void StartLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }
    public void StartLevel4()
    {
        SceneManager.LoadScene("Level 4");
    }
}
