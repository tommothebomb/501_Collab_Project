using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    [Header("// TIME VALUES //")]
    [SerializeField] float waitingTime = 5f;
    [SerializeField] float timer;

    [Header("// PREFAB COUNT //")]
    [SerializeField] int prefabCount;

    [Header("// PREFAB REFERENCES //")]
    [SerializeField] GameObject[] prefab;

    void Start()
    {
        timer = waitingTime;
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

    void FixedUpdate()
    {
    
    }

    void SpawnObject()
    {

        int i = Random.Range(0, prefabCount);

        Instantiate(prefab[i], transform.position, Quaternion.identity);
    }
}
