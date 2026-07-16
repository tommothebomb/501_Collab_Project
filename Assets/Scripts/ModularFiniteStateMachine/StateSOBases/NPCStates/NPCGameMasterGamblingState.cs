using UnityEngine;

[CreateAssetMenu(fileName = "NPCGMGambling", menuName = "State Machine/Gambling/NPC GM Gambling")]
public class NPCGameMasterGamblingState : GamblingStateSOBase
{
    // Libby Script \\
    // What will do in this state:
    // run the game the npc is at
    // Connections to other states:
    // swap back to roaming after player leaves


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
        base.DoFrameUpdateLogic();
    }

    public override void DoAnimationLogic(HumanoidBase.AnimationTriggers trigger)
    {
        base.DoAnimationLogic(trigger);
    }
}
