using UnityEngine;

[CreateAssetMenu(fileName = "NPCInteracting", menuName = "State Machine/In Menu/NPC Interacting")]
public class NPCInteractingState : MenuStateSOBase
{
    // Libby Script \\
    // What will do in this state:
    // player will stand still and face player
    // activate dialogue system and play lines
    // Connections to other states:
    // return to roaming when dialogue stops
    Transform thisNPC;
    Transform playerTransform;

    public override void Initialize(GameObject gameObject, HumanoidBase humanoid)
    {
        base.Initialize(gameObject, humanoid);
        thisNPC = gameObject.transform;
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    public override void DoEnterLogic()
    {
        Vector3 targetLook = playerTransform.position;
        targetLook.y = thisNPC.position.y;
        thisNPC.LookAt(targetLook);
        // activate dialogue canvas
        base.DoEnterLogic();
    }

    public override void DoExitLogic()
    {
        // deactivate dialogue canvas
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        // dialogue system logic?
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
