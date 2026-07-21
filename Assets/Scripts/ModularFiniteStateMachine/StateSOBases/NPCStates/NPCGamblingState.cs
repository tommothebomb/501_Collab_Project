using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "NPCGambling", menuName = "State Machine/Gambling/NPC Gambling")]
public class NPCGamblingState : GamblingStateSOBase
{
    // Libby Script \\
    // What will do in this state:
    // Npc will stand by/infront of machine, will face machine head on
    // play gambling voicelines
    // Connections to other states:
    // random timeframe decided in enter logic will decide how long will stay at game for before swapping back to roaming
    Transform thisNPC;
    HumanoidBase thisBase;
    NavMeshAgent agent;
    Transform currentStandPoint;
    StandPointLogic spl;
    // when adding voicelines find NPCVoicelineStorage on the same GO as above
    bool atPoint;
    float timeSpentAtGame;


    public override void Initialize(GameObject gameObject, HumanoidBase humanoid)
    {
        base.Initialize(gameObject, humanoid);
        thisNPC = gameObject.transform;
        thisBase = thisNPC.GetComponent<HumanoidBase>();
        agent = thisNPC.GetComponent<NavMeshAgent>();
        spl = GameObject.Find("-GameStandPoints-").GetComponent<StandPointLogic>();
    }

    public override void DoEnterLogic()
    {
        if (spl.emptyStandPoints.Count <= 0) { thisBase.stateMachine.ChangeState(thisBase.roamingState); Debug.Log("no space"); }

        atPoint = false;
        agent.enabled = true;
        int randomPoint = Random.Range(0, spl.emptyStandPoints.Count);
        currentStandPoint = spl.emptyStandPoints[randomPoint];
        spl.emptyStandPoints.RemoveAt(randomPoint); // remove from empty points list so other npcs cant take same spot
        agent.SetDestination(currentStandPoint.position);
        timeSpentAtGame = Random.Range(10, 60);
        base.DoEnterLogic();
    }

    public override void DoExitLogic()
    {
        if (!atPoint) return; // dont do any of this if never reached point

        thisNPC.Rotate(Vector3.up, 180);
        thisNPC.position += thisNPC.forward;
        agent.enabled = true;

        spl.emptyStandPoints.Add(currentStandPoint);
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        if (atPoint)
        {
            timeSpentAtGame -= Time.deltaTime;
            if (timeSpentAtGame <= 0) thisBase.stateMachine.ChangeState(thisBase.roamingState);
            // play random voicelines
        }
        else if(!atPoint && Vector3.Distance(thisNPC.position, currentStandPoint.position) < 0.5f) // point heighs MUST be set to match npc heights for this to work
        {
            atPoint = true;
            agent.enabled = false;
            thisNPC.transform.position = currentStandPoint.position;
            thisNPC.transform.rotation = currentStandPoint.rotation;
        }
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
