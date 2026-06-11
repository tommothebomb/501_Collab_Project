using TMPro;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager instance;
    [SerializeField] TMP_Text Text;
    //public float money;


    private float _money = 1000;
    public float Money
    {
        get { return _money; }
        set
        {
            _money = value;
            UpdateText(value);

        }
    } 

    private void UpdateText(float NewValue)
    {
        Text.text = $"Money : {_money}";
    }

    private void Awake()
    {
        instance = this;
    }
}

