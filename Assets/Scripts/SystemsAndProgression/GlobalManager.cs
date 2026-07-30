using TMPro;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager instance;
    [SerializeField] TMP_Text balanceText;
    //public float money;


    private float _money = 10000;
    public float Money
    {
        get { return _money; }
        set
        {
            _money = value;
            UpdateText(value);
            TestMessageManager.Instance.CheckMessage(_money);
        }
    } 

    private void UpdateText(float NewValue)
    {
        balanceText.text = $"Balance : {_money}";
    }

    private void Awake()
    {
        instance = this;
    }
}

