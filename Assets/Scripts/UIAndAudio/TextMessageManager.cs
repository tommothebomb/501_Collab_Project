using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextMessageManager : MonoBehaviour
{
    float currentMoney;
    [SerializeField] GameObject messageCanvas;
    [SerializeField] TMP_Text replaceableText;
    [SerializeField] Image replaceableIcon;

    [TextArea(4, 4)]
    [SerializeField] string[] messages;
    [SerializeField] Sprite[] icons;

    private void Update()
    {
        currentMoney = GlobalManager.instance.Money; // get value from manager

        if (currentMoney == 100) // make this a switch statement instead?
        {
            ShowTextMessage(messages[1], icons[1]); // pass in values you want
        }
    }

    void ShowTextMessage(string text, Sprite icon)
    {
        messageCanvas.SetActive(true);
        replaceableText.text = text;
        replaceableIcon.sprite = icon;
        Invoke(nameof(CloseMessage), 5); // set canvas back to inactive after 5 seconds
    }

    void CloseMessage()
    {
        messageCanvas.SetActive(false);
    }
}
