using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Attribute")]
    public float startingHealth = 20;
    public float startingMoveSpeed = 2f;
    public float startingRotateSpeed = 5f;
    public GameObject deathEffect;

    [Header("Editor Reference")]
    public float health;
    public float moveSpeed;
    public float rotateSpeed;

    [Header("Attack Related")]
    private Transform target;
    private string tagName = "Player";
    private float startingDamage = 5f;
    public float damage;
    public float attackDistance = 1.2f;
    private bool isCD = false;
    private float attackCD = 2f;

    [Header("Reward")]
    public GameObject[] energyPrefabs;
    private Rigidbody rb;


    void Start()
    {
        health = startingHealth;
        moveSpeed = startingMoveSpeed;
        damage = startingDamage;
        rotateSpeed = startingRotateSpeed;

        target = GameObject.FindGameObjectWithTag(tagName).transform;
        rb = this.GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        MoveTowardsTarget();
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= attackDistance && isCD == false)
        {
            StartCoroutine(AttackTarget());
        }
    }

    private void MoveTowardsTarget()
    {
        Vector3 moveDirection = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(moveDirection);
        rb.velocity = moveDirection.normalized * moveSpeed;
        rb.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, rotateSpeed);
    }

    private IEnumerator AttackTarget()
    {
        isCD = true;
        target.GetComponent<PlayerStats>().TakeDamage(damage);
        yield return new WaitForSeconds(attackCD);
        isCD = false;
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Instantiate(energyPrefabs[0], transform.position, Quaternion.identity);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


}
