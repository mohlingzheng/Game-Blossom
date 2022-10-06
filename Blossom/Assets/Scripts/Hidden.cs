using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hidden : MonoBehaviour
{
    public Text clickMe;

    public void Hide()
    {
        gameObject.SetActive(true);
        clickMe.text = "You Suck!";
    }

}
