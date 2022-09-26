using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    private float startingHealth = 100f;
    public float health;
    public Image healthBar;

    void Start()
    {
        health = startingHealth;
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / startingHealth;

    }
}
