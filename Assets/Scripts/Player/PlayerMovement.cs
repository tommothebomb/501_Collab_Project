using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    // Libby script \\
    [Header("Movement")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float groundDrag = 5f;
    [SerializeField] Transform groundCheckOrigin;
    Rigidbody rb;
    Vector3 moveDirection;
    LayerMask groundMask;
    bool isGrounded;
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
        rb = GetComponent<Rigidbody>();
        groundMask = LayerMask.GetMask("Ground");
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
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // limit velocity
        Vector3 flatVal = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        if (flatVal.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVal.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }
}
