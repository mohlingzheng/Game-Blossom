using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    private float startingDamage = 10f;
    public float damage;

    private float attackCDTime = 1.5f;
    private float currentTime;
    public Image autoAttackBar;

    void Start()
    {
        damage = startingDamage;
        currentTime = attackCDTime;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        autoAttackBar.fillAmount = currentTime / attackCDTime;
        if (currentTime <= 0)
        {
            Debug.Log("attack");
            PerformAutoAttack();
            currentTime = attackCDTime;
        }
    }

    private void PerformAutoAttack()
    {

    }
}
