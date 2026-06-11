using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, Mathf.Infinity))
        {
            // get iinteractible if can and do the thing
        }
    }
}
