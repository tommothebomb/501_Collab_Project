using UnityEngine;

[CreateAssetMenu(fileName = "NPCRoaming", menuName = "State Machine/Roaming/NPC Roaming")]
public class NPCRoamingState : RoamingStateSOBase
{
    // Libby Script \\
    // What will do in this state:
    // loitre 
    //
    // Connections to other states:
    // random timeframe chosen in enter logic will decide how long will walk around/loiter/play a game
    // when choose to play game will swap to gambling state once get to a machine


    public override void DoEnterLogic() { }
    public override void DoExitLogic() { ResetValues(); }
    public override void DoAnimationLogic(HumanoidBase.AnimationTriggers trigger) { }
    public override void ResetValues() { }
}
