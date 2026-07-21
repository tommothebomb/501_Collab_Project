using TreeEditor;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Game_Slots_New : InteractableObjectBase, IInterractible
{
    [SerializeField] int CostToPlay;

    //each collum will have these values
    [SerializeField] float speed;
    [SerializeField] float HiddenSpeed;
    [SerializeField] float SpinTime;
    bool caninteractwith = true;
    [SerializeField] GameObject Holder;
    public RectTransform Scaler;
    public Vector3 BaseScale;
    //public GameObject TileBase;
    float timer;
    int Loops;//how many loops we will do before moving on
    int CurrentLoop;
    [SerializeField]int FinalLaps;

    public Sprite[] Icons;
    //Winlines
    class WinLines
    {
        public Tiles Tile = Tiles.Wild;
        //add the typeing // if typing = null it hasnt been set yet
        public bool[] row0 = new bool[25];
    }

    [SerializeField] Payouts[] PayoutRewards;
    [System.Serializable]
    public class Payouts
    {
        public int[] PayoutTier = new int[3];
    }


    public class Tile
    {
        public Tiles Type;
    }
    public enum State
    {
        Start,Spin, Payout, BonusGame,End
    }
    [SerializeField] State state;
    //IS this a normal way to define the winlines?? problem is its sideways i would rather define it like
    /*
     * [1][1][1] //i mean we can swpa these to be rows so colloum 1 would get the child[at the top]
     * [0][0][0]
     */

    #region Win Line base sets
    WinLines TopTri     = new WinLines //this ones outdated instead for each line we just check each one with its own sytstem
    {
        row0 = new bool[] {true,  false, false, false ,true ,
                           false, true,  false, true  ,false ,
                           false, false, true , false ,false ,
                           false, false, false, false ,false ,
                           false, false, false, false ,false },
    };
    WinLines BottomTri  = new WinLines
    {
        row0 = new bool[] { false, false, false, false  ,false ,
                            false, false, false, false  ,false ,
                            false, false, true, false  ,false ,
                            false, true, false, true  ,false ,
                            true, false, false, false  ,true },
    };
    WinLines TopDiag    = new WinLines
    {
        row0 = new bool[] { true, false, false, false  ,false ,
                            false, true, false, false  ,false ,
                            false, false, true, false  ,false ,
                            false, false, false, true  ,false ,
                            false, false, false, false  ,true },
    };
    WinLines BottomDiag = new WinLines
    {
        row0 = new bool[] { false, false, false, false  ,true ,
                            false, false, false, true  ,false ,
                            false, false, true, false  ,false ,
                            false, true, false, false  ,false ,
                            true, false, false, false  ,false },
    };
    WinLines FirstLine  = new WinLines
    {
        row0 = new bool[] { true , true  , true , true   ,true ,
                            false, false, false, false  ,false ,
                            false, false, false, false  ,false ,
                            false, false, false, false  ,false ,
                            false, false, false, false  ,false },
    };
    WinLines SecondLine = new WinLines
    {
        row0 = new bool[] { false, false, false, false  ,false ,
                            true , true  , true , true   ,true ,
                            false, false, false, false  ,false ,
                            false, false, false, false  ,false ,
                            false, false, false, false  ,false },
    };
    WinLines ThirdLine  = new WinLines
    {
        row0 = new bool[] { false, false, false, false  ,false ,
                            false, false, false, false  ,false ,
                            true , true  , true , true   ,true ,
                            false, false, false, false  ,false ,
                            false, false, false, false  ,false },
    };
    WinLines ForthLine  = new WinLines
    {
        row0 = new bool[] { false, false, false, false  ,false ,
                            false, false, false, false  ,false ,
                            false, false, false, false  ,false ,
                            true , true  , true , true   ,true ,
                            false, false, false, false  ,false },
    };
    WinLines FithLine   = new WinLines
    {
        row0 = new bool[] { false, false, false, false  ,false ,
                            false, false, false, false  ,false ,
                            false, false, false, false  ,false ,
                            false, false, false, false  ,false ,
                            true , true  , true , true   ,true},
    };
    #endregion

    public enum Tiles
    {
        Special,Wild,HighS,MidS,LowS,Ace,King,Queen,Jack,Ten
    }

    #region RNG and Tile Rng
    /// <summary>
    /// a result of the enum with weighted probabaltys
    /// </summary>
    /// <param name="Input"></param>  number betweeh 1 & 100
    /// <returns></returns>
    float WeightedRng(float Input)
    {
        switch (Input)
        {
            case 1: //Higest Roll
                return 0;
            case <=5:  
                return 1;
            case <= 10:
                return 2;
            case <= 20:
                return 3;
            case <= 30:
                return 4;
            case <= 40:
                return 5;
            case <= 55:
                return 6;
            case <= 70:
                return 7;
            case <= 85:
                return 8;
            case <= 90:
                return 9;
            default:
                return 9;
        }
    }

    Tiles ValueToTile(float input)
    {
        switch (input)
        {
            case 0: //Higest Roll
                return Tiles.Special;
            case 1:
                return Tiles.Wild;
            case 2:
                return Tiles.HighS;
            case 3:
                return Tiles.MidS;
            case 4:
                return Tiles.LowS;
            case 5:
                return Tiles.Ace;
            case 6:
                return Tiles.King;
            case 7:
                return Tiles.Queen;
            case 8:
                return Tiles.Jack;
            case 9:
                return Tiles.Ten;
            default:
                return Tiles.Ten;
        }
    }
    #endregion

    #region Interaction functions
    public override void Interact()
    {
        if (state == State.End)
        {
            HideUIToolTip();
            state = State.Start;
            caninteractwith = false;
        }
    }

    public override void CheckToDisplayUIToolTip()
    {
        if (caninteractwith) DisplayUIToolTip();
    }
   
    #endregion

    public void PlayAttraction()
    {
        //caninteractwith.Post(this.gameObject);
    }


    private void Start()
    {
        BaseScale = Scaler.sizeDelta;
        uiTooltipObj = GameObject.FindGameObjectWithTag("ToolTip").transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        switch (state)
        {
            case State.Start:
                //start
                //set values
                HiddenSpeed = speed;
                Loops = Random.Range(50, 100);
                CurrentLoop = 0;
                state++;
                caninteractwith = false;

                GlobalManager.instance.Money -= CostToPlay;

                break;
            case State.Spin:
                Spin();
                break;
            case State.Payout:
                state+=2;// +2 to skip the bonus game
                Payout();


                caninteractwith = true;
                PlayerInteraction.instance.tooltipShown = false;
                PlayerInteraction.instance.lastHit = null;

                break;
            case State.BonusGame: //Scrapped
            case State.End: //idle State
            default:
                //do nothing until reset
                break;

        }
    }
  
    /// <summary>
    /// moves the tiles by scaling the scaler object up to a maximum size,
    /// once the maximum scale is reached it moves the bottom row to the top and give that row a set of new tiles
    /// </summary>
    void Spin()
    {

        timer += (HiddenSpeed - (float)CurrentLoop/(float)Loops) * Time.deltaTime;
        //effect the speed by the remaning amount of loops
        //Debug.Log(((float)CurrentLoop / (float)Loops));

        if (timer > SpinTime)
        {
            Transform held = Holder.transform.GetChild(0);
            held.SetSiblingIndex(Holder.transform.childCount - 2);

            //Child = tile // Held = Row
            foreach (Transform child in held)
            {
                Tiles newtile = ValueToTile(WeightedRng(Random.Range(0, 100)));     //SET THE NEW TILES VALUE
                child.GetComponent<Game_Slot_TileData>().Tile = newtile;            //SET THE VALUE IN THE TILE DATE
                child.GetComponent<Image>().sprite = Icons[(int)newtile];           //UPDATE THE SPRITE TO THE CORRSPONDING SPRITE
            }
            timer = 0;
            CurrentLoop++;
        }

        //lerping the scales this is how we move the tiles 
        float pingpong = Mathf.Lerp(BaseScale.y, BaseScale.y * 2, timer / SpinTime);
        Scaler.sizeDelta = new Vector2(BaseScale.x, pingpong);

        //if it has reached the exxpected amount of loops start slowing down
        if (CurrentLoop >= Loops)
        {
            //move to payout
            if (HiddenSpeed > 0)
            {
                HiddenSpeed -= (speed / (float)FinalLaps) * Time.deltaTime;
            }
            else
            {
                //reset the base scale object so the rows are alligend normaly
                float P = Mathf.Lerp(BaseScale.y, BaseScale.y * 2, 0);
                Scaler.sizeDelta = new Vector2(BaseScale.x, P);

                state++;//Move to next State -> Payout
            }
        }
    }

    /// <summary>
    ///checks the tile
    /// </summary>
    /// Win lines are the lines that payout
    /// a line much reach a length of 3 before paying out any amount
    void Payout()
    {
        List<WinLines> RemaningWinlines = GenrateWinlineList();
        //add all the winlines here

        List<Transform> Rows = new List<Transform>
        {
            Holder.transform.GetChild(4), Holder.transform.GetChild(3), Holder.transform.GetChild(2), Holder.transform.GetChild(1), Holder.transform.GetChild(0)
        };

        int PayoutAmount = 0;

        for (int C = 0; C < Rows[0].childCount ;C++) //for each colloum 
        {
            for (int Row = 0; Row < Rows.Count; Row++) //for each row
            {
                Tiles currentTile = Rows[Row].GetChild(C).GetComponent<Game_Slot_TileData>().Tile;  //getting the colloum loop of the rows

                //WinLine
                for (int WL = 0; WL < RemaningWinlines.Count; WL++) //loop through all the winlines remaning on this cycle
                {
                    WinLines currentWinLine = RemaningWinlines[WL]; // get the data of this winline
                    if (currentWinLine.row0[(Row * 5) + C]) // row * 5 + c = curret tile we are checking in the winline bool
                    {

                        if (currentTile == Tiles.Wild) { }                                                 //if its wild we just ignore it beacuse it will allways succeseed
                        else if (currentTile == currentWinLine.Tile || currentWinLine.Tile == Tiles.Wild)  //if the currentwinline is wild that means this winline hasnt had a value set, and make sures the current tile matches the winlines set tile
                        {
                            currentWinLine.Tile = currentTile; //set the value this winline will have to mantain to win
                            //Rows[Row].GetChild(C).gameObject.GetComponent<Image>().color = Color.green; //debuging display to show how far winlines make it
                        }
                        else //if it dont match what the winline is set, this winline officaly ends 
                        {
                            RemaningWinlines.RemoveAt(WL); //remove the failed winlines from the loop ,, most winlined will fail on the second row
                            WL--;

                            if (C >= 3) //if the winline makes it far enough payout dpending on the colloum  (line of 3,4,5 payout)
                            {
                                PayoutAmount += PayoutRewards[(int)currentTile].PayoutTier[C - 2];
                            }
                        }

                    }
                }
            }
        }

        foreach(WinLines lines in RemaningWinlines)
        {
            PayoutAmount += PayoutRewards[(int)lines.Tile].PayoutTier[2]; //payout all remaind winlines at their max reward
        }

        GlobalManager.instance.Money += PayoutAmount; //give the player their final amount of money owned
    }

    //returns a list of new winlines that arnt releated to the original winline data set so it dosnt mess with them
    List<WinLines> GenrateWinlineList()
    {
        List<WinLines> NewList = new List<WinLines>();
        List<WinLines> BaseLine = new List<WinLines> {
        FirstLine,SecondLine,ThirdLine,ForthLine,FithLine,TopTri,TopDiag,BottomTri,BottomDiag,
        };
        

        int iteration = 0;
        foreach (WinLines line in BaseLine)
        {
            NewList.Add(new WinLines
            { Tile = line.Tile,
              row0 = line.row0
            });
            iteration++;
        }
        return NewList;
    }

}

