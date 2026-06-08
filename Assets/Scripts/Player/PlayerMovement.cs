using UnityEngine;
using System;

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

    // player state machine
    public enum PlayerState
    {
        idle,
        moving,
        playingGame,
        paused
    }
    public PlayerState currentPlayerState { get; private set; } // this makes it so the variable can be read from anywhere but only changed/set in this script
    public static Action<PlayerState> OnPlayerStateChanged; // to be used if state needs to be updated and something something idk i cant figure this out


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

    // state machine 
    public void SetMoveState(PlayerState playerState)
    {
        if (playerState == currentPlayerState) return;

        switch (playerState)
        {
            case PlayerState.idle:
                break;

            case PlayerState.moving:
                break;

            case PlayerState.playingGame:
                break;

            case PlayerState.paused:
                break;

            default:
                Debug.Log("No state found");
                break;
        }

        OnPlayerStateChanged?.Invoke(playerState);
        currentPlayerState = playerState;
    }

    // updates
    private void Update()
    {
        PlayerInput();
        GroundCheck();
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
        isGrounded = Physics.CheckSphere(groundCheckOrigin.position, 1, groundMask);

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
}
