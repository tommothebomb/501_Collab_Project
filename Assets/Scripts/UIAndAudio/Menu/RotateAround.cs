using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    float randomx;
    float randomy;
    float randomz;
    
    void Start()
    {
        randomx = Random.Range(-10f, 10f);
        randomy = Random.Range(-10f, 10f);
        randomz = Random.Range(-10f, 10f);
    }
    void Update()
    {
        transform.Rotate(new Vector3(randomx, randomy, randomz) * speed * Time.deltaTime);    
    }
}
