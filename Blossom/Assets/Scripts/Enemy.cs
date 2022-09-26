using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    private string tagName = "Player";

    private float startingHealth = 20;
    public float health;

    private float startingSpeed = 2f;
    public float moveSpeed;

    private float startingDamage = 5f;
    public float damage;
    public float attackDistance = 1.2f;

    private bool isCD = false;
    private float attackCD = 2f;

    private Rigidbody rb;

    void Start()
    {
        health = startingHealth;
        moveSpeed = startingSpeed;
        damage = startingDamage;

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
        rb.velocity = moveDirection.normalized * moveSpeed;
    }

    private IEnumerator AttackTarget()
    {
        isCD = true;
        target.GetComponent<PlayerStats>().takeDamage(damage);
        yield return new WaitForSeconds(attackCD);
        isCD = false;
    }

    
}