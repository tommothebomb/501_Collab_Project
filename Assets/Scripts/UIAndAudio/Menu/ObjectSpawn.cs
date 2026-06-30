using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    // this script is for the prefab spawning of the background items
    // it takes an array of game objects and randomises which one to spawn

    [Header("// TIME VALUES //")]
    [SerializeField] float waitingTime = 5f;
    [SerializeField] float timer;

    [Header("// PREFAB COUNT //")]
    [SerializeField] int prefabCount;

    [Header("// PREFAB REFERENCES //")]
    [SerializeField] GameObject[] prefab;

    void Start()
    {
        timer = waitingTime; // timer is set to waiting time at start so the objects spawn right away
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= waitingTime) // if the timer is equal to the waiting time
        {
            SpawnObject(); // function is called
            timer = 0;
        }
    }

    void SpawnObject()
    {
        int i = Random.Range(0, prefabCount); // randomises which prefab will spawn from an array

        Instantiate(prefab[i], transform.position, Quaternion.identity); // this spawns the prefab
    }
}
