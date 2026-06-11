using UnityEngine;

public interface IInterractible
{
    // Libby Script \\
    public Sprite uiTooltipSprite { get; set; }

    public void Interact();
    public void DisplayUIToolTip();
}
