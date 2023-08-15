using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementMixamo : MonoBehaviour
{
    public Animator animator;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        /*if (verticalAxis > 0.1f)
        {
            verticalAxis = 1;
        }
        else if (verticalAxis > 0.1 && verticalAxis < 0.55f)
        {
            verticalAxis = 0;
        }*/

        Vector3 movement = transform.forward * verticalAxis + transform.right * horizontalAxis;
        movement.Normalize();
        transform.position += movement * 0.1f;

        

        animator.SetFloat("Vertical", verticalAxis);
        animator.SetFloat("Horizontal", horizontalAxis);
    }
}
