using UnityEngine;

public class HumanoidState
{
    // Libby Script \\
    protected HumanoidBase humanoid;
    protected HumanoidStateMachine hStateMachine;

    public HumanoidState(HumanoidBase humanoid, HumanoidStateMachine hStateMachine) // constructor, passes data in when instance is created of this script
    {
        this.humanoid = humanoid;
        this.hStateMachine = hStateMachine;
    }

    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void FrameUpdate() { }
    public virtual void PhsycisUpdate() { }
    public virtual void AnimationTriggerEvent(HumanoidBase.AnimationTriggers trigger) { }
}
