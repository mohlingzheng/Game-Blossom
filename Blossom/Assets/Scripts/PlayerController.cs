using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 5f;
    //public float rotateSpeed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0, zDirection);
        //Quaternion lookRotation = Quaternion.LookRotation(moveDirection);
        rb.velocity = moveDirection * moveSpeed;
        //rb.rotation = Quaternion.RotateTowards(rb.rotation, lookRotation, moveSpeed);

    }
}
