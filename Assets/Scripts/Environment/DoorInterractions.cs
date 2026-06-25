using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DoorInterractions : MonoBehaviour, IInterractible
{
    // Libby Script \\
    [SerializeField] GameObject uiTooltipSprite;


    public void DisplayUIToolTip()
    {
        if (uiTooltipSprite.activeSelf) return;
        uiTooltipSprite.SetActive(true);
    }
    public void HideUIToolTip()
    {
        if (!uiTooltipSprite.activeSelf) return;
        uiTooltipSprite.SetActive(false);
    }

    public void Interact()
    {
        // door open anim i think?
    }
}
