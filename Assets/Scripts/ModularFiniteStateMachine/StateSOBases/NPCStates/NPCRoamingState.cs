using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "NPCRoaming", menuName = "State Machine/Roaming/NPC Roaming")]
public class NPCRoamingState : RoamingStateSOBase
{
    // Libby Script \\
    // What will do in this state:
    // random timeframe chosen in enter logic will decide how long will do each action
    // actions are loiter, walk around, play games
    // Connections to other states:
    // when choose to play game will swap to gambling state once get to a machine
    int randomThing;
    float timeBetweenThings;
    Vector3 randomPoint;
    Transform thisNPC;
    HumanoidBase thisBase;
    NavMeshAgent agent;
    Bounds navmeshBounds;
    bool loitring = false;

    public override void Initialize(GameObject gameObject, HumanoidBase humanoid)
    {
        base.Initialize(gameObject, humanoid); 
        thisNPC = gameObject.transform;
        thisBase = thisNPC.GetComponent<HumanoidBase>();
        agent = thisNPC.GetComponent<NavMeshAgent>();
        navmeshBounds = GameObject.Find("Floor").GetComponent<Renderer>().bounds;
    }

    public override void DoEnterLogic()
    {
        agent.enabled = true;
        randomThing = Random.Range(0, 3); 
        timeBetweenThings = Random.Range(4, 30);

        if (randomThing == 0) loitring = true;
        else if (randomThing == 1) { loitring = false; PickRandomPoint(); }
        else thisBase.stateMachine.ChangeState(thisBase.gameState);
        base.DoEnterLogic();
    }
    public override void DoFrameUpdateLogic()
    {
        timeBetweenThings -= Time.deltaTime;
        if (timeBetweenThings <= 0 || (!loitring && Vector3.Distance(thisNPC.position, randomPoint) <= 0.3f))
        {
            randomThing = Random.Range(0, 3);
            timeBetweenThings = Random.Range(4, 30);

            if (randomThing == 0) loitring = true;
            else if (randomThing == 1) { loitring = false; PickRandomPoint(); }
            else thisBase.stateMachine.ChangeState(thisBase.gameState);
        }

        if (loitring)
        {
            // play idle anim?
        }

        base.DoFrameUpdateLogic();
    }
    public override void DoExitLogic()
    {
        agent.enabled = false;
        base.DoExitLogic();
    }
    void PickRandomPoint()
    {
        float rx = Random.Range(navmeshBounds.min.x, navmeshBounds.max.x);
        float rz = Random.Range(navmeshBounds.min.z, navmeshBounds.max.z);
        randomPoint = new Vector3(rx, thisNPC.position.y, rz);
        agent.SetDestination(randomPoint);
    }
    public override void DoAnimationLogic(HumanoidBase.AnimationTriggers trigger)
    {
        base.DoAnimationLogic(trigger);
    }
}
