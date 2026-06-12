using UnityEngine;

public class HumanoidStateMachine
{
    // Libby Script \\
    public HumanoidState currentState { get; set; }


    public void Initialize(HumanoidState startingState)
    {
        currentState = startingState;
        currentState.EnterState();
    }

    public void ChangeState(HumanoidState newState)
    {
        currentState.ExitState();
        currentState = newState;
        currentState.EnterState();
    }
}
