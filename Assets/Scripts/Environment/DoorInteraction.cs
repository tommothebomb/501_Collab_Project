using UnityEngine;
using System.Collections;

public class DoorInterractions : MonoBehaviour
{
    // Libby Script \\
    [SerializeField] Animator doorOpenCloseLeft;
    [SerializeField] Animator doorOpenCloseRight;


    public void OnTriggerEnter(Collider other)
    {
        doorOpenCloseLeft.SetBool("OpenDoor", true);
        doorOpenCloseRight.SetBool("OpenDoor", true);
    }
    private void OnTriggerExit(Collider other)
    {
        doorOpenCloseLeft.SetBool("OpenDoor", false);
        doorOpenCloseRight.SetBool("OpenDoor", false);
    }
}