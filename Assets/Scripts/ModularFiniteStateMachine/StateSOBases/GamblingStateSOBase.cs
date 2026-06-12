using UnityEngine;

public class GamblingStateSOBase : ScriptableObject
{
    // Libby Script \\
    protected HumanoidBase humanoid;
    protected GameObject gameObject;


    public virtual void Initialize(GameObject gameObject, HumanoidBase humanoid)
    {
        this.gameObject = gameObject;
        this.humanoid = humanoid;
    }

    public virtual void DoEnterLogic() { }
    public virtual void DoExitLogic() { ResetValues(); }
    public virtual void DoAnimationLogic(HumanoidBase.AnimationTriggers trigger) { }
    public virtual void ResetValues() { }
}
