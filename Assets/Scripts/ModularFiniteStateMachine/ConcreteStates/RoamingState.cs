using UnityEngine;

public class RoamingState : HumanoidState
{
    // Libby Script \\

    public RoamingState(HumanoidBase humanoid, HumanoidStateMachine hStateMachine) : base(humanoid, hStateMachine)
    {
        // called as soon as this class is initialized
    }

    public override void EnterState()
    {
        base.EnterState();
        humanoid.romaingBaseInstance.DoEnterLogic();
    }

    public override void ExitState()
    {
        base.ExitState();
        humanoid.romaingBaseInstance.DoExitLogic();
    }

    public override void AnimationTriggerEvent(HumanoidBase.AnimationTriggers trigger)
    {
        base.AnimationTriggerEvent(trigger);
        humanoid.romaingBaseInstance.DoAnimationLogic(trigger);
    }
}
