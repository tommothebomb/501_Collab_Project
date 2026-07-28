using UnityEngine;
using TMPro;
using System;

public class TimeScript : MonoBehaviour
{
    private TextMeshProUGUI timeText;

    void Start()
    {
        timeText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        timeText.text = DateTime.Now.ToString("HH:mm");
    }
}
