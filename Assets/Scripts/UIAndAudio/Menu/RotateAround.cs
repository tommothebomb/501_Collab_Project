using UnityEngine;

public class RotateAround : MonoBehaviour
{
    // this script handles the random rotation of the spawned objects

    [SerializeField] float speed = 1f;
    float randomx;
    float randomy;
    float randomz;
    
    void Start()
    {
        // below are random float values for the rotation of each axis
        randomx = Random.Range(-10f, 10f);
        randomy = Random.Range(-10f, 10f);
        randomz = Random.Range(-10f, 10f);
    }
    void Update()
    {
        transform.Rotate(new Vector3(randomx, randomy, randomz) * speed * Time.deltaTime); // rotates the object with the randomised values
    }
}
