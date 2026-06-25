using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // Libby Script \\
    IInterractible lastHit;


    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, Mathf.Infinity))
        {
            if (hit.transform.TryGetComponent(out IInterractible interactible))
            {
                lastHit = interactible;
                lastHit.DisplayUIToolTip();
            }

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }
        else
        {
            if (lastHit != null) lastHit.HideUIToolTip();
        }
    }
}
