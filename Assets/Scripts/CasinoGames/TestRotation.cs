using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEditor;

public class TestRotation : MonoBehaviour
{
    //this is a list of all values and if they are red or green 
    public Dictionary<float,bool> wheelNumber;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float Speed;
    public enum Input 
    {
        Colour,Number,OddOrEven,
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, Speed * Time.deltaTime, 0), Space.Self);
    }

    void testspin()
    {
        Spin(Input.Colour,12f);
    }


    //for odd and even use 1 and 2
    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param> the result the player is looking for,
    /// <param name="number"></param> the players inputted number
    void Spin(Input type,float number)
    {
        float result = Random.Range(0, 38);

        bool ColResult;
        wheelNumber.TryGetValue(result, out ColResult);


        bool numbcol;
        wheelNumber.TryGetValue(number,out numbcol);
        switch (type)
        {
            case Input.Colour:
                wheelNumber.TryGetValue(number, out numbcol); //gets the colour of the thingy
                if (numbcol == ColResult)
                {
                    //Win();
                }
                else
                {
                    Loss();
                }

                break;
            case Input.Number:
                //direct number
                if (number == result)
                {
                    //Win();
                }
                else
                {
                    Loss();
                }

                break;
            case Input.OddOrEven:
                //odd or even 
                float halfed = result / 2;
                halfed = halfed - Mathf.Floor(halfed);

                float inputhalef = number / 2;
                inputhalef = inputhalef - Mathf.Floor(inputhalef);
                if (halfed == inputhalef)
                {
                    //Win();
                }
                else
                {
                    Loss();
                }

                break;

        }

    }

    void Win(float betAmount , float ReturnPercent)
    {
        // money += betamount * return percentage
    }
    void Loss()
    {
        // money = money - betamount
    }
}
