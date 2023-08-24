using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementMixamo : MonoBehaviour
{
    public Animator animator;
    private Rigidbody rb;

    private float movementSpeed;
    public float walkingSpeed = 4f;
    public float sprintSpeed = 10f;

    public bool isSprinting;
    public bool isGrounded;
    public bool isJumping;
    private float jumpForce = 2.2f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        isJumping = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    private void Update()
    {
        animator.SetBool("IsGrounded", isGrounded);
        animator.SetBool("IsJumping", isJumping);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
            Jump();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
            movementSpeed = sprintSpeed;

            animator.SetBool("IsSprinting", true);
        }
        else
        {
            isSprinting = false;
            movementSpeed = walkingSpeed;
            animator.SetBool("IsSprinting", false);
        }

        Vector3 movement = transform.forward * verticalAxis + transform.right * horizontalAxis;
        movement.Normalize();
        transform.position += movement * movementSpeed * Time.deltaTime;

        animator.SetFloat("Vertical", verticalAxis);
        animator.SetFloat("Horizontal", horizontalAxis);
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
}
