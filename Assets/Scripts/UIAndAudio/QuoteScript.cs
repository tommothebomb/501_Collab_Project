using UnityEngine;
using TMPro;

public class QuoteScript : MonoBehaviour
{
    private TextMeshProUGUI quotesText;
    [SerializeField] TextMeshProUGUI namesText;

    [SerializeField] string[] quotes;
    [SerializeField] string[] names;

    private int lastIndex = -1;

    void Awake()
    {
        quotesText = GetComponent<TextMeshProUGUI>();
    }

    void OnEnable()
    {
        if (quotes.Length == 0) return;

        int randomIndex;

        do
        {
            randomIndex = Random.Range(0, quotes.Length);
        }
        
        while (quotes.Length > 1 && randomIndex == lastIndex);

        lastIndex = randomIndex;

        quotesText.text = quotes[randomIndex];
        namesText.text = names[randomIndex];
    }
}
