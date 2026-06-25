using UnityEngine;
public class PlayerInteraction : MonoBehaviour
{
    // Libby Script \\
    [SerializeField] Transform playerT;
    IInterractible lastHit;
    bool tooltipShown = false;
    InputSystem_Actions inputActs;


    private void OnEnable()
    {
        inputActs = new InputSystem_Actions();
        inputActs.Player.Enable();
        inputActs.Player.Interact.performed += ctx => CheckCanInteract();
    }

    void Update()
    {        
        Debug.DrawRay(playerT.position, transform.TransformDirection(Vector3.forward) * 6, Color.blue);

        RaycastHit hit;
        if (Physics.Raycast(playerT.position, transform.TransformDirection(Vector3.forward), out hit, 6))
        {
            if (hit.transform.TryGetComponent(out IInterractible interactible))
            {
                Debug.Log("hit interractable");
                if (!tooltipShown)
                {
                    lastHit = interactible;
                    lastHit.DisplayUIToolTip();
                    tooltipShown = true;
                }
            }
        }
        else
        {
            if (lastHit == null) return;
            lastHit.HideUIToolTip();
            tooltipShown = false;
            lastHit = null;
        }
    }

    void CheckCanInteract()
    {
        if (lastHit != null) lastHit.Interact();
    }
}
