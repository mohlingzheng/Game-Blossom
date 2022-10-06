using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string loadScene = "GameScene";

    public void Play()
    {
        SceneManager.LoadScene(loadScene);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
