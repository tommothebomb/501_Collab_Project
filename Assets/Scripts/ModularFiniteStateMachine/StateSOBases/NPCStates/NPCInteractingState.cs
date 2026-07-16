using System.Threading.Tasks;
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
    HumanoidBase thisBase;
    Transform playerTransform;

    public override void Initialize(GameObject gameObject, HumanoidBase humanoid)
    {
        base.Initialize(gameObject, humanoid);
        thisNPC = gameObject.transform;
        thisBase = thisNPC.GetComponent<HumanoidBase>();
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    public override void DoEnterLogic()
    {
        // activate dialogue canvas
        ReturnToRoaming();
        base.DoEnterLogic();
    }

    async void ReturnToRoaming()
    {
        Debug.Log("called function");
        await Task.Delay(3000);
        Debug.Log("waited 5 seconds");
        thisBase.stateMachine.ChangeState(thisBase.roamingState);
    }

    public override void DoExitLogic()
    {
        // deactivate dialogue canvas
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        Vector3 targetLook = playerTransform.position;
        targetLook.y = thisNPC.position.y;
        thisNPC.LookAt(targetLook);
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
