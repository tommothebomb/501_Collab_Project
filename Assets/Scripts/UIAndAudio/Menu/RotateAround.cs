using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float xRotation;
    [SerializeField] float yRotation;
    [SerializeField] float zRotation;

    void Update()
    {
        transform.Rotate(new Vector3(xRotation, yRotation, zRotation) * speed * Time.deltaTime);    
    }
}
