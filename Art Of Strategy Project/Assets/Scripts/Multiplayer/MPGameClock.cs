using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class MPGameClock : MonoBehaviour
{
    private Text textClock;
    private int hour = 12;
    static float minute = 0;
    private GameObject sun;
    public bool night = false;

    void Start (){
        textClock = GetComponent<Text>();
        sun = GameObject.Find("Light");
    }

    void Update (){
        if (GameObject.Find("MPController").GetComponent<MPGameController>().startGame)
        {
            minute += Time.deltaTime * 4.5f;
            sun.transform.Rotate(0, -Time.deltaTime * 1.1f, 0, Space.Self);
            if (minute > 59)
            {
                minute = 0;
                if (hour > 22)
                {
                    hour = 0;
                }
                else
                {
                    hour++;
                }
            }
            if (hour <= 19 && hour >= 7)
            {
                textClock.text = LeadingZero(hour) + ":" + LeadingZero(Mathf.RoundToInt(minute));
                night = false;
            }
            else
            {
                textClock.text = LeadingZero(hour) + ":" + LeadingZero(Mathf.RoundToInt(minute)) + " Night";
                night = true;
            }
        }
    }

    string LeadingZero (int n){
        return n.ToString().PadLeft(2, '0');
    }

    static public int GetTime()
    {
        return ((int)minute);
    }
}
