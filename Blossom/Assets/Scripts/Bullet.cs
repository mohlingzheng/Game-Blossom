using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 10f;

    private float startingDamage = 10f;
    public float damage;

    private Transform target;
    private Vector3 moveDirection;
    private string tagName = "Enemy";
    void Start()
    {
        damage = startingDamage;
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.velocity = moveDirection.normalized * moveSpeed;
    }

    public void SeekTarget(Transform _target)
    {
        target = _target;
        moveDirection = target.position - transform.position;
        moveDirection.y = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagName))
        {
            other.GetComponent<Enemy>().takeDamage(damage);
            Destroy(gameObject);
        }
    }
}
