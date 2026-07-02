using UnityEngine;

public class InteractableObjectBase : MonoBehaviour, IInterractible
{
    // Libby Script \\
    [SerializeField] GameObject uiTooltipObj; // set this to whichever tooltip image its meant to use (these can be found in inspector under 'tooltips')
    [SerializeField] Transform spawnPos; // set to pos of wherever you want the tooltip to show, usually just set as object transform


    void Start()
    {
        /*uiTooltipPrefab = Instantiate(uiTooltipPrefab, spawnPos.position, spawnPos.rotation);
        uiTooltipPrefab.SetActive(false);*/
    }

    public virtual void CheckToDisplayUIToolTip()
    {
        // implemented in derrived class IF NEEDED
    }
    public void DisplayUIToolTip()
    {
        if (uiTooltipObj.activeSelf) return;
        uiTooltipObj.transform.position = spawnPos.transform.position;
        uiTooltipObj.SetActive(true);
    }
    public void HideUIToolTip()
    {
        if (!uiTooltipObj.activeSelf) return;
        uiTooltipObj.SetActive(false);
    }

    public virtual void Interact()
    {
        // MUST be implemented in derrived class
    }
}
