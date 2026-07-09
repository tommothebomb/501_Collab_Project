using UnityEngine;

[CreateAssetMenu(fileName = "NPCRoaming", menuName = "State Machine/Roaming/NPC Roaming")]
public class NPCGameMasterRoamingState : RoamingStateSOBase
{
    // Libby Script \\
    // What will do in this state:
    // random timeframe chosen in enter logic will decide how long will do each action
    // actions are loiter, walk around, play games
    // Connections to other states:
    // when choose to play game will swap to gambling state once get to a machine


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

    public override void ResetValues()
    {
        base.ResetValues();
    }
    public override void DoAnimationLogic(HumanoidBase.AnimationTriggers trigger)
    {
        base.DoAnimationLogic(trigger);
    }
}
