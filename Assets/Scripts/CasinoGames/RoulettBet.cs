using UnityEngine;

public class RoulettBet : InteractableObjectBase, IInterractible
{
    [SerializeField] Game_Roulette logic;
    [SerializeField] Game_Roulette.Input BetStyle;

    [SerializeField] float inputNumber;

    public override void Interact()
    {
        if (logic.Isplaying) { return; }
        //TO DO ADD CODE TO MNOT ALOOW BETTING IF CURRNTLY SPINNING
        logic.PlaceChips(this.transform.position);
        switch (BetStyle)
        {
            case Game_Roulette.Input.Number:
                logic.BetOnNumber(inputNumber);
                break;
            case Game_Roulette.Input.OddOrEven:
                logic.BetOnOddorEven(inputNumber);
                break;
            case Game_Roulette.Input.Colour:
                logic.BetOnColour(inputNumber);
                break;
        }
        HideUIToolTip();
    }

    public override void CheckToDisplayUIToolTip()
    {
        if (logic.Isplaying) { return; }
        uiTooltipObj.transform.Rotate(Vector3.up * Random.Range(0, 360));
         DisplayUIToolTip();
    }
}
