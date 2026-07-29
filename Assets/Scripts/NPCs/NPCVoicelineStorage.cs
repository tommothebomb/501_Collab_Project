using UnityEngine;

public class NPCVoicelineStorage : MonoBehaviour
{
    public npcType thisNPC;
    public bool playedLine = false;
    public enum npcType
    {
        BigLad,
        Douche,
        Farmer,
        Geezer,
        Idk,
        Loser,
        Polka,
        RegularGuy,
        Smoker,
        ZestyRichGuy
    }

    public void SetEnum(npcType npc)
    {
        thisNPC = npc;
    }

    public void PlayVoiceLine(GameObject obj)
    {
        Debug.Log("npc spoke");
        Debug.Log("Play_" + thisNPC.ToString());
        if (!playedLine) AkUnitySoundEngine.PostEvent("Play_" + thisNPC.ToString(), obj );
        playedLine = true;
    }
}
