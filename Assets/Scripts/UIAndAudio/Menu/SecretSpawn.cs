using UnityEngine;

public class SecretSpawn : MonoBehaviour
{
    // this script is a secret

    [Header("// TIME VALUES //")]
    [SerializeField] float waitingTime = 5f;
    [SerializeField] float timer;

    [Header("// PREFAB REFERENCES //")]
    [SerializeField] GameObject prefab;

    void Start()
    {
        //timer = waitingTime;
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= waitingTime)
        {
            SpawnObject();
            timer = 0;
        }
    }

    void SpawnObject()
    {
        Instantiate(prefab, transform.position, Quaternion.identity); 
    }
}
