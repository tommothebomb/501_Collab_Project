using System;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    // Libby script \\
    float moveSpeed = 6f; // does not need to be exposed in editor as changing it in editor will do nothing
    [SerializeField] float walkSpeed = 6f;
    [SerializeField] float sprintSpeed = 12f;
    [SerializeField] float groundDrag = 5f;
    [SerializeField] Transform groundCheckOrigin;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float jumpCooldown = 0.25f;
    [SerializeField] float airMultiplier = 0.4f;
    Rigidbody rb;
    Vector3 moveDirection;
    LayerMask groundMask;
    bool isGrounded;
    bool canJump;
    InputSystem_Actions inputActs;
    float stepTimer;


    // input system and component gets
    private void OnEnable()
    {
        inputActs = new InputSystem_Actions();
        inputActs.Player.Enable();
        inputActs.Player.Jump.performed += ctx => Jump();
        inputActs.Player.Sprint.started += ctx => SetToSprintSpeed();
        inputActs.Player.Sprint.canceled += ctx => SetToWalkSpeed();

        rb = GetComponent<Rigidbody>();
        groundMask = LayerMask.GetMask("Ground");
        canJump = true;
    }
    private void OnDisable() => inputActs.Player.Disable();

    // updates
    private void Update()
    {
        PlayerInput();
        GroundCheck();
        ChangeFootSteps();
    }
    private void FixedUpdate() => MovePlayer();

    // player input and movement handling 
    void PlayerInput()
    {
        moveDirection = inputActs.Player.Move.ReadValue<Vector2>();
        moveDirection = transform.forward * moveDirection.y + transform.right * moveDirection.x;
    }
    void GroundCheck()
    {
        isGrounded = Physics.CheckBox(groundCheckOrigin.position, new Vector3(0.5f, 0.5f, 0.5f), Quaternion.identity, groundMask);

        if (isGrounded) rb.linearDamping = groundDrag;
        else rb.linearDamping = 0;
    }
    void MovePlayer()
    {
        if (isGrounded) rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        else rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

        // limit velocity
        Vector3 flatVal = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        if (flatVal.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVal.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
        stepTimer += Time.deltaTime;
        switch (moveSpeed)
        {
            case 6:
                if (stepTimer >= 3)
                {
                    AkUnitySoundEngine.PostEvent("Play_FootStepsContainer", this.gameObject);
                    stepTimer = 0;
                }
                break;
            case 12:
                if (stepTimer >= 1)
                {
                    AkUnitySoundEngine.PostEvent("Play_FootStepsContainer", this.gameObject);
                    stepTimer = 0;
                }
                break;
        }
    }
    void Jump()
    {
        if (canJump && isGrounded)
        {
            canJump = false;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }
    void ResetJump() => canJump = true;
    void SetToSprintSpeed() => moveSpeed = sprintSpeed;
    void SetToWalkSpeed() => moveSpeed = walkSpeed;

    void ChangeFootSteps()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down), Color.red);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, groundMask))
        {
            switch (hit.collider.tag)
            {
                case ("Stone"):
                    AkUnitySoundEngine.SetSwitch("Floor", "Concrete", this.gameObject);
                    break;
                case ("Wood"):
                    AkUnitySoundEngine.SetSwitch("Floor", "Wood", this.gameObject);
                    break;
                case ("Grass"):
                    AkUnitySoundEngine.SetSwitch("Floor", "Grass", this.gameObject);
                    break;
            }
        }
    }
}
