using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string loadScene = "GameScene";
    public Text highScore;

    private void Start()
    {
        highScore.text = PlayerPrefs.GetFloat("highScore").ToString();
    }
    public void Play()
    {
        SceneManager.LoadScene(loadScene);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
