using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public float attackCDTime = 1.5f;
    private float currentTime;
    public Image autoAttackBar;
    public Transform attackPoint;

    public GameObject bulletPrefabs;

    private string tagName = "Enemy";
    private Transform target;

    void Start()
    {
        currentTime = attackCDTime;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        autoAttackBar.fillAmount = currentTime / attackCDTime;
        if (currentTime <= 0)
        {
            PerformAutoAttack();
            currentTime = attackCDTime;
        }
    }

    private void PerformAutoAttack()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tagName);
        float closetDistance = Mathf.Infinity;
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, transform.position);
            if (distance <= closetDistance)
            {
                closetDistance = distance;
                target = enemy.transform;
            }

        }
        if (target != null)
        {
            GameObject bullet = Instantiate(bulletPrefabs, attackPoint.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().SeekTarget(target);
        }
    }
}
