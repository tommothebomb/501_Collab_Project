using UnityEngine;

public class RoulettBet : InteractableObjectBase, IInterractible
{
    [SerializeField] Game_Roulette logic;
    [SerializeField] Game_Roulette.Input BetStyle;

    [SerializeField] float inputNumber;

    public override void Interact()
    {
        //TO DO ADD CODE TO MNOT ALOOW BETTING IF CURRNTLY SPINNING

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

    }

    public override void CheckToDisplayUIToolTip()
    {
        uiTooltipObj.transform.Rotate(Vector3.up * Random.Range(0, 360));
         DisplayUIToolTip();
    }
}
