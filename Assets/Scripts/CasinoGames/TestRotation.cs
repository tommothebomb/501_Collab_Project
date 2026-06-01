using UnityEngine;

public class TestRotation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float Speed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, Speed * Time.deltaTime, 0), Space.Self);
    }
}
