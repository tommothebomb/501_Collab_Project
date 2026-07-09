using UnityEngine;

public class NPCInteraction : InteractableObjectBase
{
    // Libby Script \\
    HumanoidBase npc;


    private void Start()
    {
        npc = GetComponent<HumanoidBase>();
    }

    public override void Interact()
    {
        // swap npc state to interacting (menu) state
        npc.stateMachine.ChangeState(npc.menuState);
    }
}
