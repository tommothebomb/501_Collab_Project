using AK.Wwise;
using UnityEngine;

public class WwiseLogicForCasion : MonoBehaviour
{
    public Bank bank;
    void Update()
    {
        bank.Load();
    }


}
