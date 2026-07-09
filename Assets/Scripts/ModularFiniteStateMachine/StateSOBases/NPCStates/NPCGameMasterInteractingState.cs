using UnityEngine;

[CreateAssetMenu(fileName = "NPCInteracting", menuName = "State Machine/In Menu/NPC Interacting")]
public class NPCGameMasterInteractingState : MenuStateSOBase
{
    // Libby Script \\
    // What will do in this state:
    // play dialogue before player plays game
    // asks player if wants to play
    // Connections to other states:
    // if player selects yes swap to gambling state
    // if player selects no swap to roaming state


    public override void Initialize(GameObject gameObject, HumanoidBase humanoid)
    {
        base.Initialize(gameObject, humanoid);
    }

    public override void DoEnterLogic()
    {
        // make npc look at player
        // activate dialogue script for this object
        base.DoEnterLogic();
    }

    public override void DoExitLogic()
    {
        // deactivate dialogue script for this gameobject
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

