using UnityEngine;

public class AlwaysLookAtPlayer : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
    }
}
