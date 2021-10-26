using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rgbd;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float speed = 5;

    [SerializeField]
    private float turnSpeed = 20;
    
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
        rgbd.AddRelativeForce(Vector3.forward * speed * verticalInput * Time.deltaTime * power);
    }

    public void JumpTrigger()
    {
        animator.SetTrigger("Jump");
    }

}
