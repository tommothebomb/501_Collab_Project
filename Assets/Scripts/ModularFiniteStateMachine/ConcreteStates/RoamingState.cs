using UnityEngine;

public class RoamingState : HumanoidState
{
    // Libby Script \\
    GameObject player;
    PlayerMovement playerMovement;
    MouseMovement mouseMovement;
    PlayerInteraction interaction;

    public RoamingState(HumanoidBase humanoid, HumanoidStateMachine hStateMachine) : base(humanoid, hStateMachine)
    {
        // called as soon as this class is initialized
        player = GameObject.FindWithTag("Player");

        playerMovement = player.GetComponent<PlayerMovement>();
        mouseMovement = player.GetComponentInChildren<MouseMovement>();
        interaction = player.GetComponent<PlayerInteraction>();
    }

    public override void AnimationTriggerEvent(HumanoidBase.AnimationTriggers trigger)
    {
        base.AnimationTriggerEvent(trigger);
    }

    public override void EnterState()
    {
        Debug.Log("now in roaming");
        playerMovement.enabled = true;
        mouseMovement.enabled = true;
        interaction.enabled = true;
    }

    public override void ExitState()
    {
        playerMovement.enabled = false;
        mouseMovement.enabled = false;
        interaction.enabled = false;
    }
}
