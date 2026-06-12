using UnityEngine;

public class PlayingGameState : HumanoidState
{
    // Libby Script \\

    public PlayingGameState(HumanoidBase humanoid, HumanoidStateMachine hStateMachine) : base(humanoid, hStateMachine)
    {
        // called as soon as this class is initialized
    }

    public override void EnterState()
    {
        base.EnterState();
        humanoid.gamblingBaseInstance.DoEnterLogic();
    }

    public override void ExitState()
    {
        base.ExitState();
        humanoid.gamblingBaseInstance.DoExitLogic();
    }

    public override void AnimationTriggerEvent(HumanoidBase.AnimationTriggers trigger)
    {
        base.AnimationTriggerEvent(trigger);
        humanoid.gamblingBaseInstance.DoAnimationLogic(trigger);
    }
}
