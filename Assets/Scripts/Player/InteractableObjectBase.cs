using UnityEngine;

public class InteractableObjectBase : MonoBehaviour
{
    // Libby Script \\
    [SerializeField] GameObject uiTooltipPrefab; // prefab for this is currently an elephant image
    [SerializeField] Transform spawnPos; // set to pos of wherever you want the tooltip to show, usually just set as object transform


    void Start()
    {
        uiTooltipPrefab = Instantiate(uiTooltipPrefab, spawnPos.position, spawnPos.rotation);
        uiTooltipPrefab.SetActive(false);
    }

    public void DisplayUIToolTip()
    {
        if (uiTooltipPrefab.activeSelf) return;
        uiTooltipPrefab.SetActive(true);
    }
    public void HideUIToolTip()
    {
        if (!uiTooltipPrefab.activeSelf) return;
        uiTooltipPrefab.SetActive(false);
    }
}
