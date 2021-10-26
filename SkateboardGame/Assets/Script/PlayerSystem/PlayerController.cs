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

    private void Awake()
    {
        rgbd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        verticalInput = Input.GetAxis("Vertical");

       

        var angle = Time.deltaTime * turnSpeed * horizontalInput;

        transform.Rotate(Vector3.up, angle);

        transform.position += Time.deltaTime * speed * verticalInput * Vector3.forward;
    }
    private void FixedUpdate()
    {
        //print(verticalInput);
        //Vector3 force = Vector3.forward * speed * Time.deltaTime * verticalInput;
        //print(force);
       // rgbd.AddForce(force);
    }
}
