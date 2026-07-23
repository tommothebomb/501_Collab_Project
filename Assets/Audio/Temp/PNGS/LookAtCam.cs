using UnityEngine;

public class LookAtCam : MonoBehaviour
{
    public bool faceCam;
    public float rotateSpeed;
    void Update()
    {
        if (faceCam) transform.LookAt(Camera.main.transform);
        else transform.Rotate(new Vector3(0,rotateSpeed * Time.deltaTime,0));
    }

}
