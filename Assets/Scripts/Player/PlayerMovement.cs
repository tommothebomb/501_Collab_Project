using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    // Libby script
    Rigidbody rb;

    public enum PlayerState
    {
        idle,
        moving,
        playingGame,
        paused
    }
    public PlayerState currentPlayerState { get; private set; } // this makes it so the variable can be read from anywhere but only changed/set in this script
    public static Action<PlayerState> OnPlayerStateChanged; // to be used if state needs to be updated and something something idk i cant figure this out


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

    private void Update()
    {
        // move things when press button
    }
}
