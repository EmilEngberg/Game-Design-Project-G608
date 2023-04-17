using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public int speed = 10;
    private Rigidbody2D characterBody;
    public Animator animator;
    private Vector3 moveDirection;


    void Start()
    {
        animator = GetComponent<Animator>();
        characterBody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(moveX, moveY, 0f).normalized;

        animator.SetFloat("moveX", moveDirection.x);
        animator.SetFloat("moveY", moveDirection.y);

        if (moveDirection != Vector3.zero)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void FixedUpdate()
    {
        characterBody.velocity = new Vector3(moveDirection.x * speed, moveDirection.y * speed);
    }
}