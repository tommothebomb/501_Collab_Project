using UnityEngine;

[CreateAssetMenu(fileName = "PlayerGambling", menuName = "State Machine/Gambling/Player Gambling")]
public class PlayerGamblingState : GamblingStateSOBase
{
    // Libby Script \\

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
        //Debug.Log("entered gambling");
        base.DoExitLogic();
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
