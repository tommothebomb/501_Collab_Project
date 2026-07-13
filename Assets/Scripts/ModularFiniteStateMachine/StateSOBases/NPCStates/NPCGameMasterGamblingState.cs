using UnityEngine;

[CreateAssetMenu(fileName = "NPCGMGambling", menuName = "State Machine/Gambling/NPC GM Gambling")]
public class NPCGameMasterGamblingState : GamblingStateSOBase
{
    // Libby Script \\
    // What will do in this state:
    // will run the game for the player, which game depends on the table is at
    // Connections to other states:
    // when player leaves table will go back to roaming


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
