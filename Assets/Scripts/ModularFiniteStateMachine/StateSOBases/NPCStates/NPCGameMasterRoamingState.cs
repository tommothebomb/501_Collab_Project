using UnityEngine;

[CreateAssetMenu(fileName = "NPCGMRoaming", menuName = "State Machine/Roaming/NPC GM Roaming")]
public class NPCGameMasterRoamingState : RoamingStateSOBase
{
    // Libby Script \\
    // What will do in this state:
    // play idle animation
    // Connections to other states:
    // swap to interacting state when player interacts


    public override void Initialize(GameObject gameObject, HumanoidBase humanoid)
    {
        base.Initialize(gameObject, humanoid);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        // play idle anim
        base.DoFrameUpdateLogic();
    }
    public override void DoAnimationLogic(HumanoidBase.AnimationTriggers trigger)
    {
        base.DoAnimationLogic(trigger);
    }
}
