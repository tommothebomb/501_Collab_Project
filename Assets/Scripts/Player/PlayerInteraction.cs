using UnityEngine;
public class PlayerInteraction : MonoBehaviour
{
    // Libby Script \\
    [SerializeField] Transform playerT;
    IInterractible currentHit;
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
        //Debug.DrawRay(playerT.position, transform.TransformDirection(Vector3.forward) * 6, Color.blue);

        RaycastHit hit;
        if (Physics.Raycast(playerT.position, transform.TransformDirection(Vector3.forward), out hit, 6))
        {
            if (hit.transform.TryGetComponent(out IInterractible interactible))
            {
                currentHit = interactible;
                if (currentHit != lastHit)
                {
                    lastHit.HideUIToolTip();
                    tooltipShown = false;
                    lastHit = currentHit;
                }
                if (!tooltipShown)
                {
                    currentHit = interactible;
                    currentHit.DisplayUIToolTip();
                    tooltipShown = true;
                }
            }
        }
        else
        {
            if (currentHit == null) return;
            currentHit.HideUIToolTip();
            tooltipShown = false;
            currentHit = null;
            lastHit = null;
        }
    }

    void CheckCanInteract()
    {
        if (currentHit != null) currentHit.Interact();
    }
}
