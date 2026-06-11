using System.Collections;
using UnityEngine;

public class Game_Slots_Old : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] Transform[] Reels = new Transform[3];
    [SerializeField] Phase Temp;
    [SerializeField] float timer;
    float delaytime;
    int reelsSpinning = 0;

    enum Phase
    {
        Start,Spinning,End
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= delaytime)
        {
            timer = 0;
            delay();
        }

        switch (Temp)
        {
            case Phase.Start:

                break;
            case Phase.Spinning:
                Spinning(reelsSpinning);
                break;
            case Phase.End:

                break;

        }




    }

    void delay()
    {
        switch (Temp)
        {
            case Phase.Start:
                Temp = Phase.Spinning;
                delaytime = 3f;
                break;
            case Phase.Spinning:
                if (reelsSpinning < 3)
                {
                    decelerate(reelsSpinning);
                    float subdelay =  Random.Range(1, 6) ;
                    delaytime = 3 + subdelay; //add randomised delayed
                    reelsSpinning++;
                }
                else
                {
                    Temp = Phase.End;
                }
                break;
            case Phase.End:
                //run the end script,, destroy 
                break;

        }
    }


    void decelerate(float reel)
    {

        if (reelsSpinning <= 1) { return; }
        //get the last wheel at slow it down
        //Reels[reelsSpinning - 1];


        //round to the nearest 60*
        //Reels[reel].rotation

        //calculate the rotation left in the spin
        //turn to the closest 60* angel
        //lerp to that angle instead of fixed rotation
    }

    //something like a corotines

    public void Spin()
    {
        Temp = Phase.Spinning;
    }

    public void Spinning(int reelcount)
    {
        for (int i = reelcount; i < Reels.Length; i++)
        {
            Reels[i].Rotate(Vector3.right * speed * Time.deltaTime, Space.Self);
        }
    }

}
