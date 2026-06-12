using UnityEngine;

public class PlayingGameState : HumanoidState
{
    // Libby Script \\

    public PlayingGameState(HumanoidBase humanoid, HumanoidStateMachine hStateMachine) : base(humanoid, hStateMachine)
    {
        // called as soon as this class is initialized
    }

    public override void AnimationTriggerEvent(HumanoidBase.AnimationTriggers trigger)
    {
        base.AnimationTriggerEvent(trigger);
    }

    public override void EnterState()
    {
        Debug.Log("now playing game");
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
