using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScoreUpdate : MonoBehaviour
{

    public Text scoreText;
    private float score;
    private float highScore;

    private void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
        highScore = PlayerPrefs.GetFloat("highScore");
    }

    public void GainScore(float marks)
    {
        score += marks;
        scoreText.text = score.ToString();
        if (score > highScore)
        {
            PlayerPrefs.SetFloat("highScore", score);
            Debug.Log(score);
        }
    }
}
