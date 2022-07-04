using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{

    public Joystick joystick;
    public Joystick RightJoystick;
    public FixedButton fixedButton;
    private Rigidbody rb;
    public float movespeed;

    public float jumpForce;
    public bool isGrounded;
    public Transform groundcheck;
    public float groundCheckRadius;
    public LayerMask LayerIsGround;

    protected float CameraAngle;
    protected float CameraAngleSpeed = 5f;



    void Start()
    {
        //joystick = FindObjectOfType<Joystick>();
        fixedButton = FindObjectOfType<FixedButton>();

        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundcheck.position, groundCheckRadius, LayerIsGround);

        rb.velocity = new Vector3(joystick.Horizontal * movespeed, rb.velocity.y, joystick.Vertical * movespeed);
        if (isGrounded && fixedButton.pressed)
        {
            rb.velocity += Vector3.up * jumpForce;
        }



        CameraAngle += RightJoystick.Horizontal * CameraAngleSpeed;
        

        Camera.main.transform.position = transform.position + Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0, 5, -20);
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2f - Camera.main.transform.position, Vector3.up);
    }

    
}
