using UnityEngine;

public class HumanoidBase : MonoBehaviour
{
    // Libby Script \\
    [SerializeField] protected float walkSpeed;
    public enum AnimationTriggers
    {
        npcWalk,
        npcInteractedWith
    }


    public virtual void AnimationTriggerEvent(AnimationTriggers trigger)
    {
        // make animation go brr
    }
}
