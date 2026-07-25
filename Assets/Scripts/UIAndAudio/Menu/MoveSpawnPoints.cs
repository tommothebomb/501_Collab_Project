using UnityEngine;

public class MoveSpawnPoints : MonoBehaviour
{
    [SerializeField] float distance = 2f;
    [SerializeField] float speed = 2f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float xOffset = Mathf.Sin(Time.time* speed) * distance;

        transform.position = new Vector3(startPos.x + xOffset, startPos.y, startPos.z);
    }
}
