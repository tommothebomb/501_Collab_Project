using UnityEngine;

public class InMenuState : HumanoidState
{
    // Libby Script \\
    // need to add canvas enable and disable logic here
    InputSystem_Actions inputActs;


    public InMenuState(HumanoidBase humanoid, HumanoidStateMachine hStateMachine) : base(humanoid, hStateMachine)
    {
        // called as soon as this class is initialized
    }

    public override void AnimationTriggerEvent(HumanoidBase.AnimationTriggers trigger)
    {
        base.AnimationTriggerEvent(trigger);
    }

    public override void EnterState()
    {
        Debug.Log("now in menu");
        inputActs = new InputSystem_Actions();
        inputActs.UI.Enable();
    }

    public override void ExitState()
    {
        inputActs.UI.Disable();
    }
}
