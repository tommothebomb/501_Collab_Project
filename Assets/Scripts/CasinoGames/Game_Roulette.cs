using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Game_Roulette : MonoBehaviour
{
    [SerializeField] float MaxBet;

    [Header("Return to Player % ")]
    [SerializeField] float ColourRTP; //they are all the same length YIPPIE!!!!!!!!!!!!!!!!!!!!!!
    [SerializeField] float NumberRTP;
    [SerializeField] float OddOrERTP; 

    // A List of every Number and its accociated Colour
    private Dictionary<float, bool> wheelNumber = new Dictionary<float, bool> 
    {   //FASLE = Red , TRUE == black 
        { 0, false },
        { 1, true },
        { 2, false },
        { 3, true },
        { 4, false },
        { 5, true },
        { 6, false },
        { 7, true },
        { 8, false },
        { 9, true },
        { 10, false },
        { 11, false },
        { 12, true },
        { 13, false },
        { 14, true },
        { 15, false },
        { 16, true },
        { 17, false },
        { 18, true },
        { 19, true },
        { 20, false },
        { 21, true },
        { 22, false },
        { 23, true },
        { 24, false },
        { 25, true },
        { 26, false },
        { 27, true },
        { 28, false },
        { 29, false },
        { 30, true },
        { 31, false },
        { 32, true },
        { 33, false },
        { 34, true },
        { 35, false },
        { 36, true },
    };
    //Player Input Type
    public enum Input
    {
        Colour, Number, OddOrEven,
    }

    public void BetOnNumber(float Number)
    {
        Code(Input.Number, Number, RandomMethod(), MaxBet);
    }

    public void BetOnOddorEven(float Number) //either 1 or 2
    {
        Code(Input.OddOrEven, Number, RandomMethod(), MaxBet);
    }

    public void BetOnColour(float Number) //either 1 or 2
    {
        Code(Input.Colour, Number, RandomMethod(), MaxBet);
    }


    //WORK IN PROGRESSES
    /// <summary>
    /// Decides the result of the spin via simulation or animation
    /// </summary>
    float AnimationMethod()
    {
        return 0;
    }

    float RandomMethod()
    {
        //if the bet type does need the number its fineeeeeeeeeeeeeeeeeeeeeeeeeeeeeee
        return Random.Range(0, 36);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="Type"></param> the type of result we base are win off
    /// <param name="PlayerBet"></param> the guessed number of the player,,, for color we default to 1 - black 2 - red // make sure the numbers match
    /// <param name="Result"></param> the resulting randomised number
    /// <param name="BetAmount"></param> the amount of money
    void Code(Input Type,float PlayerBet,float Result,float BetAmount)
    {
        GlobalManager.instance.Money -= BetAmount; // take away the money needed for the bet

        if (Result == 0)
        {
            Debug.Log("0 NO WINNERS");
            Loss(BetAmount);
        }
        Debug.Log(Result);
        switch (Type)
        {
            case Input.Colour: //If the colour matches the color of the bet number
                bool numberColour;
                wheelNumber.TryGetValue(PlayerBet, out numberColour); //gets the colour of the thingy
                bool ColResult; 
                wheelNumber.TryGetValue(Result, out ColResult);
                Debug.Log(numberColour);
                Debug.Log(ColResult);
                if (numberColour == ColResult)
                {
                    Win(MaxBet, ColourRTP);
                }
                else
                {
                    Loss(BetAmount);
                }

                break;
            case Input.Number:  //direct number
                if (PlayerBet == Result)
                {
                    Win(MaxBet, NumberRTP);
                }
                else
                {
                    Loss(BetAmount);
                }

                break;
            case Input.OddOrEven:
                //odd or even 
                /*float halfed = Result / 2;
                halfed = halfed - Mathf.Floor(halfed);

                

                float inputhalef = PlayerBet / 2;
                inputhalef = inputhalef - Mathf.Floor(inputhalef);*/
                if (Result % 2 == PlayerBet % 2)
                {
                    Win(MaxBet, OddOrERTP);
                }
                else
                {
                    Loss(BetAmount);
                }

                break;

        }
    }



    /// <param name="betAmount"></param> the amount of money the player bet
    /// <param name="ReturnToPlayer"></param> the % that the game will return to the player -- the bad ending :(
    void Win(float betAmount,float ReturnToPlayer)
    {
        GlobalManager.instance.Money += betAmount * ReturnToPlayer;
        Debug.Log("Winner!!!!!");
    }

    /// <param name="betAmount"></param> the amount of money the players going to lose -- the good ending
    void Loss(float betAmount)
    {
        Debug.Log("Loss");
    }
}
