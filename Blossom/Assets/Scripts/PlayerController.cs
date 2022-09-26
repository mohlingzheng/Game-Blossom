using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 0.01f;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0, zDirection);
        //transform.position += moveDirection * moveSpeed;
        rb.velocity = moveDirection * moveSpeed;
    }
}
