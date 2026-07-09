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
    Transform thisNPC;
    HumanoidBase thisBase;
    NavMeshAgent agent;
    Vector3 randomPoint;
    Bounds navmeshBounds;
    int randomThing;
    float timeBetweenThings;


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
        randomThing = Random.Range(0, 2);
        timeBetweenThings = Random.Range(10, 60);
        base.DoEnterLogic();
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        // pick random from 1-3
        // if 1, stand still and play random voicelines till timer up
        // if 2, walk around aimlessly and play random voicelines till timer up
        // if 3, swap to gambling state
        // if timer up, reroll time and thing

        timeBetweenThings -= Time.deltaTime;
        if (timeBetweenThings <= 0)
        {
            randomThing = Random.Range(0, 2);
            timeBetweenThings = Random.Range(10, 60);
            if (randomThing == 1)
            {
                float rx = Random.Range(navmeshBounds.min.x, navmeshBounds.max.x);
                float rz = Random.Range(navmeshBounds.min.z, navmeshBounds.max.z);
                randomPoint = new Vector3(rx, thisNPC.position.y, rz);
                agent.SetDestination(randomPoint);
            }
        }

        switch (randomThing)
        {
            case 0:
                // play random voicelines
                break;
            case 1:
                // go to random point and wait till next call
                break;
            case 2:
                thisBase.stateMachine.ChangeState(thisBase.gameState);
                break;
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
