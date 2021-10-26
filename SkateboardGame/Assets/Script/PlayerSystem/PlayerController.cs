using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rgbd;

    public float speed = 5;

    public float turnSpeed = 20;

    private float horizontalInput;

    private float verticalInput;

    private float power = 400f;

    private void Awake()
    {
        rgbd = GetComponent<Rigidbody>();
    }


    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        float angle = Time.deltaTime * turnSpeed * horizontalInput;

        transform.Rotate(Vector3.up, angle);

    }
    void FixedUpdate()
    {
        verticalInput = Input.GetAxis("Vertical");
        rgbd.AddForce(Vector3.forward * speed * verticalInput * Time.deltaTime * power);
    }
}
