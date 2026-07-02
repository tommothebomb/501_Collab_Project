using UnityEngine;

public class InteractableObjectBase : MonoBehaviour, IInterractible
{
    // Libby Script \\
    [SerializeField] GameObject uiTooltipPrefab; // prefab for this is currently an elephant image
    [SerializeField] Transform spawnPos; // set to pos of wherever you want the tooltip to show, usually just set as object transform


    void Start()
    {
        uiTooltipPrefab = Instantiate(uiTooltipPrefab, spawnPos.position, spawnPos.rotation);
        uiTooltipPrefab.SetActive(false);
    }

    public virtual void CheckToDisplayUIToolTip()
    {
        // implemented in derrived class IF NEEDED
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

    public virtual void Interact()
    {
        // MUST be implemented in derrived class
    }
}
