using UnityEngine;

public class InteractableObjectBase : MonoBehaviour
{
    // Libby Script \\
    [SerializeField] GameObject uiTooltipPrefab;
    [SerializeField] Transform spawnPos;


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
