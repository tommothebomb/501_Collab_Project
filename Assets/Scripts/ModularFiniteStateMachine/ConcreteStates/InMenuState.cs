using UnityEngine;

public class InMenuState : HumanoidState
{
    // Libby Script \\

    public InMenuState(HumanoidBase humanoid, HumanoidStateMachine hStateMachine) : base(humanoid, hStateMachine)
    {
        // called as soon as this class is initialized
    }

    public override void EnterState()
    {
        base.EnterState();
        humanoid.menuBaseInstance.DoEnterLogic();
    }

    public override void ExitState()
    {
        base.ExitState();
        humanoid.menuBaseInstance.DoExitLogic();
    }

    public override void AnimationTriggerEvent(HumanoidBase.AnimationTriggers trigger)
    {
        base.AnimationTriggerEvent(trigger);
        humanoid.menuBaseInstance.DoAnimationLogic(trigger);
    }
}
