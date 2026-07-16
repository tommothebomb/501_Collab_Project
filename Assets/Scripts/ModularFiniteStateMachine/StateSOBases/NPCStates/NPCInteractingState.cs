using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

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
    NavMeshAgent agent;

    public override void Initialize(GameObject gameObject, HumanoidBase humanoid)
    {
        base.Initialize(gameObject, humanoid);
        thisNPC = gameObject.transform;
        thisBase = thisNPC.GetComponent<HumanoidBase>();
        agent = thisNPC.GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    public override void DoEnterLogic()
    {
        // activate dialogue canvas
        agent.enabled = false;
        ReturnToRoaming();
        base.DoEnterLogic();
    }

    async void ReturnToRoaming()
    {
        Debug.Log("dialogue play");
        await Task.Delay(3000);
        thisBase.stateMachine.ChangeState(thisBase.roamingState);
    }

    public override void DoExitLogic()
    {
        agent.enabled = true;
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
