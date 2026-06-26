using UnityEngine;

public class SlotsInteraction : InteractableObjectBase
{
    // Libby Script \\
    [SerializeField] Game_Slots_Old slotsScr;


    public void Interact()
    {
        slotsScr.Spin();
    }
}
