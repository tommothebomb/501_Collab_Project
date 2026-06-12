using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }
    }
}
