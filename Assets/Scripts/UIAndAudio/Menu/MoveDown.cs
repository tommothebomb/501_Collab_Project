using UnityEngine;

public class MoveDown : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    void FixedUpdate()
    {
        Vector3 move = new Vector3(0, speed, 0);
        this.transform.Translate(move);
    }
}
