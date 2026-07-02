using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Game_Slots_Old : InteractableObjectBase, IInterractible
{
    //Haiii\\
    [SerializeField] float Payment;

    [SerializeField] Transform[] Reels = new Transform[3];
    [SerializeField] Phase currentPhase;
    [SerializeField] float timer;
    [SerializeField] float delaytime = 5;
    bool canInterractWith = true;

    [SerializeField] float[] EndGoal = new float[3];

    float currentRotationValue;
    float BaseEndGoalRotation { get; } = 3600;//this is where we add the shimmy ahhh shimmy yay
    float EndGoalRotation;

    [SerializeField] Animation anim;

    [Header("Payout Rewards")]
    float reward;
    float SpinCost = 100;
    Dictionary<float ,float> PayoutOptions = new Dictionary<float, float>() 
    {
          { 0  ,0}
        , { 60 ,1}
        , { 120,2}
        , { 180,3}
        , { 240,1}
        , { 300,2}
    };

    enum Phase
    {
        Start,Spinning,Payout,End
    }

    void Update()
    {
        switch (currentPhase)
        {
            case Phase.Start:
                //PAYMENT
                GlobalManager.instance.Money -= Payment;
                anim.Play();
                //0 = lep           1/4   2/5
                //1 = A  = 4
                //2 = clover = 5
                //3 = pot
                //4 = A
                //5 = clover

                EndGoal[0] = Random.Range(0, 6) * 60;
                EndGoal[1] = Random.Range(0, 6) * 60;
                EndGoal[2] = Random.Range(0, 6) * 60;
                currentPhase++;
                break;
            case Phase.Spinning:
                timer += Time.deltaTime;
                if (timer > delaytime)
                {
                    timer = 0;
                    currentPhase++;
                    return;
                }


                SlotsV2(0, timer + 0.3f);
                SlotsV2(1, timer + 0.15f);
                SlotsV2(2, timer + 0.05f);
                break;
            case Phase.Payout:
                currentPhase++;
                Payout();
                break;
            case Phase.End:
                canInterractWith = true;
                break;
        }

    }

    /*void delay()
    {
        /*switch (Temp)
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
        currentPhase++;
    }*/

    /*void decelerate(int reel)
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
    }*/


    void SlotsV2(int reel,float time)
    {
        EndGoalRotation = EndGoal[reel] + BaseEndGoalRotation;

        float meow = Mathf.Lerp(currentRotationValue, EndGoalRotation, time /delaytime);
        //decide the final face

        Reels[reel].localEulerAngles = new Vector3(meow,0,0);
   
    }
    //something like a corotines

    public void Payout()
    {
        float output1 = 0;
        float output2 = 0;
        float output3 = 0;
        PayoutOptions.TryGetValue(EndGoal[0], out output1);
        PayoutOptions.TryGetValue(EndGoal[1], out output2);
        PayoutOptions.TryGetValue(EndGoal[2], out output3);

        if (output1 == output2 && output1 == output3)
        {
            Debug.Log("WINNER");

            switch (output1) //avg 11% win rate
            {
                case 0: //0.005
                    Debug.Log("leprocorny joke");   //16/24 return?
                    GlobalManager.instance.Money += 24;
                    break;
                case 1: //0.08
                    Debug.Log("one of them"); // 8-9x return
                    GlobalManager.instance.Money += 8;
                    break;
                case 2: //0.08 //8-9 return
                    Debug.Log("Clover?");
                    GlobalManager.instance.Money += 8;
                    break;
                case 3://0.005 // 16/24 return
                    Debug.Log("POT OF GREED, I DRAW 2");
                    GlobalManager.instance.Money += 24;

                    break;
                default:
                    Debug.Log("DEFAULT I FUCKED YUPPPP");
                    break;
            }
            //currentPhase = Phase.Start;
        }
        else
        {
            Debug.Log("Loser");
            //currentPhase = Phase.Start;
        }
    }

    public override void Interact()
    {
        if (currentPhase == Phase.End)
        {
            HideUIToolTip();
            currentPhase = Phase.Start;
            canInterractWith = false;
        }
    }

    public override void CheckToDisplayUIToolTip()
    {
        if (canInterractWith) DisplayUIToolTip();
    }
}
