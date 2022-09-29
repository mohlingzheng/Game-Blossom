using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    private float startingHealth = 100f;
    public float health;
    public Image healthBar;

    public float experience;
    public int level = 1;

    public GameObject overlayUI;

    public GameObject levelUpEffectPrefabs;

    void Start()
    {
        health = startingHealth;
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / startingHealth;
    }

    public void gainExperience(float exp)
    {
        experience += exp;
        if (experience >= 100)
        {
            experience -= 100;
            level++;
            GameObject inst = Instantiate(levelUpEffectPrefabs, transform.position, Quaternion.identity);
            inst.GetComponent<Effects>().Seek(transform);
            overlayUI.GetComponent<Display>().UpdateLevel(level);
            Debug.Log("level up");
        }
    }
}
