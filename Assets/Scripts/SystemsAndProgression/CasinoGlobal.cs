using UnityEngine;

public class CasinoGlobal : MonoBehaviour
{
    //this script will track casino stuff


    float[] MoneyProgressionThreshHolds;// need a new variable name
    bool[] progression;


    void TempName()
    {
        if (MoneyProgressionThreshHolds[0] > GlobalManager.instance.Money && progression[0])
        {
            //run progression code
        }
    }


}
