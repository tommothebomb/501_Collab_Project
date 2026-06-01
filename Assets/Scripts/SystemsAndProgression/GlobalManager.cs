using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager instance;

    public float Money;

    private void Start()
    {
        instance = this;
    }
}

