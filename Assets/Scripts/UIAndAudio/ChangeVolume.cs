using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{
    public Slider music, sfx, master;

    void Update()
    {
        AkUnitySoundEngine.SetRTPCValue("MusicVolume", music.value);
        AkUnitySoundEngine.SetRTPCValue("MasterVolume", master.value);
        AkUnitySoundEngine.SetRTPCValue("SFXVolume", sfx.value);
    }
}
