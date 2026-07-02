using UnityEngine;

[CreateAssetMenu(fileName = "NPCInteracting", menuName = "State Machine/In Menu/NPC Interacting")]
public class NPCInteractingState : MenuStateSOBase
{
    // Libby Script \\
    // What will do in this state:
    //
    //
    // Connections to other states:
    //
    //

    public override void DoEnterLogic() { }
    public override void DoExitLogic() { ResetValues(); }
    public override void DoAnimationLogic(HumanoidBase.AnimationTriggers trigger) { }
    public override void ResetValues() { }
}
