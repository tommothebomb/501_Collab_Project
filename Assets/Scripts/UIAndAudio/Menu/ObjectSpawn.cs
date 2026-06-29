using System;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    [SerializeField] float waitingTime = 5f;
    [SerializeField] float timer;
    
    [SerializeField] GameObject menuSlot;

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
        Instantiate(menuSlot, transform.position, Quaternion.identity);
    }
}
