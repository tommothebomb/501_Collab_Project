using UnityEngine;
using TMPro;

public class TextMessageManager : MonoBehaviour
{
    public float currentMoney;
    public float previousMoney;
    [SerializeField] GameObject messageNotification;
    [SerializeField] TMP_Text replaceableText;
    [SerializeField] TMP_Text replaceableNameText;

    [TextArea(4, 4)]
    [SerializeField] string[] messages;
    [SerializeField] string[] names;

    private bool shown900Message = false;
    private bool shown700Message = false;
    private bool shown500Message = false;
    private bool shown300Message = false;
    private bool shown100Message = false;

    private void Update()
    {
        currentMoney = GlobalManager.instance.Money; // get value from manager

        if (currentMoney != previousMoney)
        {
            CheckMessages();
            previousMoney = currentMoney;
        }
    }

    void CheckMessages()
    {
        if (currentMoney <= 900 && !shown900Message)
        {
            ShowTextMessage(messages[0], names[0]);
            shown900Message = true;
        }
        if (currentMoney <= 700 && !shown700Message)
        {
            ShowTextMessage(messages[1], names[1]);
            shown700Message = true;
        }
        if (currentMoney <= 500 && !shown500Message)
        {
            ShowTextMessage(messages[2], names[2]);
            shown500Message = true;
        }
        if (currentMoney <= 300 && !shown300Message)
        {
            ShowTextMessage(messages[3], names[3]);
            shown300Message = true;
        }
        if (currentMoney <= 100 && !shown100Message)
        {
            ShowTextMessage(messages[4], names[4]);
            shown100Message = true;
        }
    }

    void ShowTextMessage(string text, string nameText)
    {
        messageNotification.SetActive(true);
        replaceableText.text = text;
        replaceableNameText.text = nameText;
        Invoke(nameof(CloseMessage), 5); // set canvas back to inactive after 5 seconds
    }

    void CloseMessage()
    {
        messageNotification.SetActive(false);
    }
}
