using UnityEngine;

public class MoveDown : MonoBehaviour
{
    // this script controls the "gravity" on the falling objects
    // rigidbody physics are stinky so I am using this 

    [SerializeField] float speed = 1f;

    void FixedUpdate()
    {
        Vector3 move = new Vector3(0, speed, 0);
        this.transform.Translate(move);
    }
}
