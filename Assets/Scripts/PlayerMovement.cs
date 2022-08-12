using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2;
    public float windSpeed;
    private Vector3 direction = Vector3.zero;
    public Transform orientation;

    public float groundDrag;

    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    private bool isRunning = false;

    public float horizontalInput;
    public float verticleInput;

    Vector3 moveDirection;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        direction = Random.insideUnitSphere;
        direction.y = 0;
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        MyInput();

        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
            moveSpeed = moveSpeed * 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
            moveSpeed = moveSpeed / 2;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticleInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        rb.AddForce(direction * windSpeed, ForceMode.Force);

        moveDirection = orientation.forward * verticleInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    public bool GetIsRunning()
    {
        return isRunning;
    }
}
