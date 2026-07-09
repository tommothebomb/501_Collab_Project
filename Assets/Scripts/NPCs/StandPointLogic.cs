using UnityEngine;
using System.Collections.Generic;

public class StandPointLogic : MonoBehaviour
{
    public List<Transform> emptyStandPoints = new List<Transform>();


    private void Start()
    {
        foreach (Transform t in this.transform)
        {
            emptyStandPoints.Add(t);
        }
    }
}
