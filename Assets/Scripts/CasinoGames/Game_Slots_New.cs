using TreeEditor;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class Game_Slots_New : MonoBehaviour
{
    //each collum will have these values
    [SerializeField] float speed;
    [SerializeField] float SpinTime;
    [SerializeField] GameObject Holder;
    public RectTransform Scaler;
    public Vector3 BaseScale;
    //public GameObject TileBase;
    float timer;
    int Loops;//how many loops we will do before moving on
    int CurrentLoop;

    public Sprite[] Icons;
    //Winlines
    class WinLines
    {
        //add the typeing // if typing = null it hasnt been set yet
        public bool[] row0 = new bool[5];
        public bool[] row1 = new bool[5];
        public bool[] row2 = new bool[5];
        public bool[] row3 = new bool[5];
        public bool[] row4 = new bool[5];
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
    WinLines TopRow = new WinLines //this ones outdated instead for each line we just check each one with its own sytstem
    {
        row0 = new bool[5] { true, true, true, true, true },
        row1 = new bool[5] { false, false, false, false ,false },
        row2 = new bool[5] { false, false, false, false ,false },
        row3 = new bool[5] { false, false, false, false ,false },
        row4 = new bool[5] { false, false, false, false ,false },
    };

    WinLines AnotherRow = new WinLines
    {
        row0 = new bool[5] { false, false, false, false, false },
        row1 = new bool[5] { true, true, true, true, true },
        row2 = new bool[5] { false, false, false, false, false },
        row3 = new bool[5] { false, false, false, false, false },
        row4 = new bool[5] { false, false, false, false, false },
    };
    //HOW WIN LINES WORK
    //if the bool is true it will check that space,
    //once that space is checked for the first time and define its type
    //it will then check all of true spaces untill it finds a one that dosnt match and then that winline is discarded
    //if all places have been chacked and some winlines remain they will payout with their RTP%/Reward Multipleier

    //IF 3 specials are hit we enter the sepcial game and thats gonna be fun


    public enum Tiles
    {
        Special,Wild,HighS,MidS,LowS,Ace,King,Queen,Jack,Ten
    }

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


    private void Start()
    {
        BaseScale = Scaler.sizeDelta;
    }

    private void Update()
    {
        switch (state)
        {
            case State.Start:
                //start
                //set values
                Loops = Random.Range(500, 1000);
                state++;
                break;
            case State.Spin:
                // Just move the size thingy asmany times as we want
                Spin();
                break;
            case State.Payout:
                break;
            case State.BonusGame:
                break;
            //check for paylines and all that Jazz
            case State.End:
            default:
                //do nothing until reset
                break;

        }
    }

    //PLACEHOLDER CLASS BUT THIS WILL REPEISENT A SINGLE COLLUM OF VALUES THAT WAAAAAAAA
  

    void Spin()
    {

        timer += (speed - ((float)CurrentLoop/(float)Loops)) * Time.deltaTime;
        //effect the speed by the remaning amount of loops
        Debug.Log(((float)CurrentLoop / (float)Loops));

        if (timer > SpinTime)
        {
            Transform held = Holder.transform.GetChild(0);
            held.SetSiblingIndex(Holder.transform.childCount - 2);

            //Child = tile // Held = Row
            foreach (Transform child in held)
            {
                Tiles newtile = ValueToTile(WeightedRng(Random.Range(0, 100)));
                child.GetComponent<Game_Slot_TileData>().Tile = newtile;
                child.GetComponent<Image>().sprite = Icons[(int)newtile];
            }
            timer = 0;
            CurrentLoop++;
        }
            //mWAIT IM USING UI ELEMENETS
            //we ping pong the scaler grouping to move them, once it get to smallest size we add a new cube/move the bottom cube to the top and re randomise it
            //we can then get the child objects of the gird and the last 5ish (mins the very last one beacuse that should be offscreen to make the move smoother)
            //that then give the collum
            //we win!!! amaze amaze amaze!!!
            float pingpong = Mathf.Lerp(BaseScale.y, BaseScale.y * 2, timer / SpinTime);
            Scaler.sizeDelta = new Vector2(BaseScale.x, pingpong);

        if (CurrentLoop >= Loops)
        {
            //move to payout
            state++;
        }
    }

    void Payout()
    {
        //check for paylines

        //check for atleast 3 bonus tiles
            //if atleast 3 , state = Staate.Bonusgame, else go to endStep and pass the turn  (funny little magic refrance for you)
        //give money

        

    }
}

