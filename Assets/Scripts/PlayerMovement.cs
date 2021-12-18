using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4;
    public Vector3 change;
    private Rigidbody2D myRigidBody;
    private Animator animator;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // Manage input for movement
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        if(change.x == 0)
            change.y = Input.GetAxisRaw("Vertical");

        // Run
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 6;
            animator.speed = 1.5f;
        }
        else
        {
            speed = 4;
            animator.speed = 1f;
        }

        // Update animation and movement
        if (change != Vector3.zero)
        {
            myRigidBody.MovePosition(transform.position + change.normalized * speed * Time.deltaTime);
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
