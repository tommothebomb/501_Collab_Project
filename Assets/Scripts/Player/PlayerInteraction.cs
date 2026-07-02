using UnityEngine;
public class PlayerInteraction : MonoBehaviour
{
    // Libby Script \\
    [SerializeField] Transform playerT;
    [SerializeField] GameObject uiPrefab;
    [SerializeField] LayerMask mask;
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
        //Debug.DrawRay(playerT.position, transform.TransformDirection(Vector3.forward) * 5, Color.blue);

        RaycastHit hit;
        if (Physics.Raycast(playerT.position, transform.TransformDirection(Vector3.forward), out hit, 5, mask))
        {
            if (hit.transform.TryGetComponent(out IInterractible interactible))
            {
                currentHit = interactible;
                if (lastHit != null && currentHit != lastHit)
                {
                    lastHit.HideUIToolTip();
                    tooltipShown = false;
                }
                if (!tooltipShown)
                {
                    currentHit = interactible;
                    currentHit.CheckToDisplayUIToolTip();
                    tooltipShown = true;
                }
                lastHit = currentHit;
            }
            else
            {
                if (currentHit == null) return;
                currentHit.HideUIToolTip();
                lastHit.HideUIToolTip();
                tooltipShown = false;
                currentHit = null;
                lastHit = null;
            }
        }
        else
        {
            if (currentHit == null) return;
            currentHit.HideUIToolTip();
            lastHit.HideUIToolTip();
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
