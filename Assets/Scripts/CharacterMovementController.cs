using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{

    public Joystick joystick;
    public FixedButton fixedButton;
    private Rigidbody rb;
    public float movespeed;

    public float jumpForce;
    public bool isGrounded;
    public Transform groundcheck;
    public float groundCheckRadius;
    public LayerMask LayerIsGround;



    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        fixedButton = FindObjectOfType<FixedButton>();
    }

    
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundcheck.position, groundCheckRadius, LayerIsGround);

        rb.velocity = new Vector3(joystick.Horizontal * movespeed, rb.velocity.y, joystick.Vertical * movespeed);

        if (isGrounded && fixedButton.pressed)
        {
            rb.velocity += Vector3.up * jumpForce;
        }
    }
}
