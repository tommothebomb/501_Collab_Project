using UnityEngine;

public class PlayAmb : MonoBehaviour
{
    public AkAmbient ambient;
    public AkRoom room;
    bool played = false;

    private void Awake()
    {
        room = GetComponent<AkRoom>();
        ambient = GetComponent<AkAmbient>();
    }

    private void Update()
    {
        if (AkUnitySoundEngine.IsInitialized())
        {
            if (room != null && !played)
            {
                //room.PostRoomTone();
                played = true;
            }
            if (ambient != null && !played)
            {
                //ambient.enableActionOnEvent = false;
                //ambient.HandleEvent(this.gameObject);
                played = true;
            }

        }

    }
}
