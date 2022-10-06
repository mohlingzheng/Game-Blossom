using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 10f;

    private float startingDamage = 10f;
    private float level;
    public float damage;

    private Transform target;
    private Vector3 moveDirection;
    private string tagName = "Enemy";
    void Start()
    {
        damage = startingDamage;
        rb = this.GetComponent<Rigidbody>();
        level = (float)GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().level;
        IncreaseDamage();
        StartCoroutine(SelfDestroy());
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
            other.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

    public void IncreaseDamage()
    {
        float damageIncreased = (level - 1) / 0.1f;
        damage = startingDamage * (1 + damageIncreased);
    }
}
