using UnityEngine;
using System.Collections.Generic;

public class StandPointLogic : MonoBehaviour
{
    public List<Transform> emptyStandPoints = new List<Transform>();


    private void Awake()
    {
        foreach (Transform t in gameObject.transform)
        {
            emptyStandPoints.Add(t);
        }
    }
}
