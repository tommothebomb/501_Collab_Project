using UnityEngine;

[CreateAssetMenu(fileName = "NPCGambling", menuName = "State Machine/Gambling/NPC Gambling")]
public class NPCGamblingState : GamblingStateSOBase
{
    // Libby Script \\
    // What will do in this state:
    // Npc will stand by/infront of machine, will face machine head on
    // play gambling voicelines
    // Connections to other states:
    // random timeframe decided in enter logic will decide how long will stay at game for before swapping back to roaming


    public override void DoEnterLogic() { }
    public override void DoExitLogic() { ResetValues(); }
    public override void DoAnimationLogic(HumanoidBase.AnimationTriggers trigger) { }
    public override void ResetValues() { }
}
