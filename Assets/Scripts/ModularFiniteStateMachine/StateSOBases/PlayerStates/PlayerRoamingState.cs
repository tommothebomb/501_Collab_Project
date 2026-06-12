using UnityEngine;

[CreateAssetMenu(fileName = "PlayerRoaming", menuName = "State Machine/Roaming/Player Roaming")]
public class PlayerRoamingState : RoamingStateSOBase
{
    // Libby Script \\
    GameObject player;
    PlayerMovement playerMovement;
    MouseMovement mouseMovement;
    PlayerInteraction interaction;


    public override void Initialize(GameObject gameObject, HumanoidBase humanoid)
    {
        base.Initialize(gameObject, humanoid);
        // i think this is suppopsed to go here?
        player = GameObject.FindWithTag("Player");

        playerMovement = player.GetComponent<PlayerMovement>();
        mouseMovement = player.GetComponentInChildren<MouseMovement>();
        interaction = player.GetComponent<PlayerInteraction>();
    }

    public override void DoEnterLogic()
    {
        //Debug.Log("entered roaming");
        playerMovement.enabled = true;
        mouseMovement.enabled = true;
        interaction.enabled = true;
    }

    public override void DoExitLogic()
    {
        playerMovement.enabled = false;
        mouseMovement.enabled = false;
        interaction.enabled = false;
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
