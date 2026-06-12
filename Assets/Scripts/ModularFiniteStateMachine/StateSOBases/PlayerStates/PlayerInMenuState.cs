using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInMenu", menuName = "State Machine/In Menu/Player In Menu")]
public class PlayerInMenuState : MenuStateSOBase
{
    // Libby Script \\
    // add canvas enable and disable logic in a seperate script
    InputSystem_Actions inputActs;


    public override void Initialize(GameObject gameObject, HumanoidBase humanoid)
    {
        base.Initialize(gameObject, humanoid);
    }

    public override void DoEnterLogic()
    {
        //Debug.Log("entered menu");
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        inputActs = new InputSystem_Actions();
        inputActs.UI.Enable();
    }

    public override void DoExitLogic()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        inputActs.UI.Disable();
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
