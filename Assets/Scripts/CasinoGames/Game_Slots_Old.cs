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
    [SerializeField]float exposed; //debug code
    [SerializeField] float exposed1; //debug code
    [SerializeField] float exposed2; //debug code
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


    void decelerate(int reel)
    {

        if (reelsSpinning < 1) { return; }
        //get the last wheel at slow it down
        //Reels[reelsSpinning - 1];



        float Progress = Mathf.Lerp(0, delaytime,timer/delaytime); //this is the progression towards the end
        exposed = Progress;
        if (Progress < 0.9f)
        {
            //slow down
            float SlowProgress = Mathf.InverseLerp(0, 0.9f, Progress);
            exposed1 = SlowProgress;
            //just rotate but slow the speed
        }
        else
        {
            //fix
            float FixProgress = Mathf.InverseLerp(0.9f, 1,Progress);

            float end = Mathf.Floor(Reels[reel - 1].rotation.x / 60) * 60; //get this to right face/angle

            //set the rotation of the reel-1 to the end
            exposed2 = FixProgress;
        }
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
