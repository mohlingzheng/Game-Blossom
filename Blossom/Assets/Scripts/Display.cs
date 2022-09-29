using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    public Text levelText;
    
    public void UpdateLevel(int level)
    {
        levelText.text = level.ToString();
    }
}
