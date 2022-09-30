using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    private string tagName = "Enemy";

    [Header("AutoAttack")]
    public GameObject bulletPrefabs;
    public float attackCDTime = 1.5f;
    private float currentTime;
    public Image autoAttackBar;
    public Transform attackPoint;

    [Header("LaserAttack")]
    public GameObject laserPrefabs;
    private GameObject laserEffect;
    private LineRenderer lineRenderer;
    public float laserCDTime = 5f;
    private bool laserOn = true;
    public int chainNumber = 3;
    private float laserDamage = 20f;


    void Start()
    {
        currentTime = attackCDTime;
        CreateLaserEffect();
        StartCoroutine(ToggleLaserAttack());
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
        PerformLaserAttack();
    }

    private Transform GetClosetTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tagName);
        Transform target = null;
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
        return target;
    }

    private void PerformAutoAttack()
    {
        Transform target = GetClosetTarget();
        if (target != null)
        {
            GameObject bullet = Instantiate(bulletPrefabs, attackPoint.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().SeekTarget(target);
        }
    }

    private void CreateLaserEffect()
    {
        laserEffect = Instantiate(laserPrefabs, transform.position, Quaternion.identity);
        lineRenderer = laserEffect.GetComponent<LineRenderer>();
    }

    IEnumerator ToggleLaserAttack()
    {
        yield return new WaitForSeconds(2.5f);
        laserOn = !laserOn;
        StartCoroutine(ToggleLaserAttack());
    }

    private void PerformLaserAttack()
    {
        if (laserOn == true)
        {
            Transform target = GetClosetTarget();
            if (target != null)
            {
                float damageRate = laserDamage * Time.deltaTime;
                target.gameObject.GetComponent<Enemy>().takeDamage(damageRate);
                if (lineRenderer.enabled == false)
                {
                    lineRenderer.enabled = true;
                }
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, target.position);
            }
            else if (target == null)
            {
                if (lineRenderer.enabled == true)
                {
                    lineRenderer.enabled = false;
                }
            }
        }
        else if (laserOn == false)
        {
            if (lineRenderer.enabled == true)
            {
                lineRenderer.enabled = false;
            }
        }
    }
}
