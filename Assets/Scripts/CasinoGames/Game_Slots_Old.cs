using System.Collections;
using System.Collections.Concurrent;
using UnityEngine;

public class Game_Slots_Old : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] Transform[] Reels = new Transform[3];
    [SerializeField] Phase Temp;
    [SerializeField] float timer;
    float delaytime;
    int reelsSpinning = 0;
    [SerializeField]float exposed; //debug code
    float Endgoal; //debug code
    [SerializeField] float exposed2; //debug code
    float endFace; //the face that we are aming to land on
    bool temporary;
    //int reelsSpun = 0; 

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
                decelerate(reelsSpinning);
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
                    float subdelay =  Random.Range(60, 360) ;
                    delaytime = (subdelay /60); //add randomised delayed
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


    void decelerate(int reel)
    {

        if (reelsSpinning < 1) { return; }
        //get the last wheel at slow it down
        //Reels[reelsSpinning - 1];



        float Progress = Mathf.InverseLerp(0, delaytime,timer); //this is the progression towards the end
        //exposed = Progress;
        if (Progress < 0.9f)
        {
            
            float bad = Progress + 0.1f;
            float P4 = bad * bad * bad * bad;
            exposed = P4;
            Reels[reel-1].Rotate(Vector3.right * (speed * (-P4 + 1)) * Time.deltaTime, Space.Self);
            
            //Reels[reel-1].Rotate(Vector3.right * speed * Time.deltaTime, Space.Self);
            //just rotate but slow the speed

            temporary = false;
        }
        else if (temporary)
        {
            //fix
            float FixProgress = Mathf.InverseLerp(0.9f, 1,Progress);
            float output = Mathf.Lerp(Reels[reel - 1].localEulerAngles.x, Endgoal, FixProgress);

            //Reels[reel - 1].localEulerAngles = new Vector3(output, 0, 0);
        }
        else
        {
            temporary = true;

            endFace = Random.Range(1, 6);
        }
    }


    void DecelerateV2(int reel)
    {

        //decide the final face


        //slow down and end on that final face


        //fix any problems

        //lockin the result and if its the final face end the loop and reward the player

    }
    //something like a corotines

    public void Payout()
    {
        //play the special effects
        //give the player the money 
    }


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
