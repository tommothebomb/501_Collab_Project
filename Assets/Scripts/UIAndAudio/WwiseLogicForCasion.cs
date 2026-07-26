using AK.Wwise;
using UnityEngine;
using UnityEngine.Timeline;

public class WwiseLogicForCasion : MonoBehaviour
{
    public string bankName;
    bool bankLoaded;
    private void Start()
    {
        AkUnitySoundEngine.SetRTPCValue("MusicVolume", 100);
        AkUnitySoundEngine.SetRTPCValue("MasterVolume", 100);
        AkUnitySoundEngine.SetRTPCValue("SFXVolume", 100);
    }

    private void Update()
    {
        if (!bankLoaded)
        {
            uint bankID;
            bankID = AkUnitySoundEngine.GetIDFromString(bankName);
            AkUnitySoundEngine.LoadBank(bankID);
            bankLoaded = true;
        }
    }
}
