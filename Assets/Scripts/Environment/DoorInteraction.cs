using UnityEngine;
using UnityEngine.UI;

public class DoorInterractions : InteractableObjectBase, IInterractible
{
    // Libby Script \\

    public override void Interact()
    {
        Debug.Log("door open animation");
    }
}