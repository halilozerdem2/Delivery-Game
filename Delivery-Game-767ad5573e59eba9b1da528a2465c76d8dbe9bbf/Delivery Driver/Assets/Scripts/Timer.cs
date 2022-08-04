using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Timer : MonoBehaviour
{
   
    [SerializeField] public Text timerText;
    public static string timer;
    public static bool finished=false;
    public static float startTime;
    public void Start()
    {   
       startTime=Time.time;    
    }

    public void Update()
    {
        if(!finished) 
        {
            float t = Time.time-startTime;

            string minutes=((int) t / 60).ToString();
            string seconds= (t % 60).ToString("f2");
            
            timer=timerText.text= minutes + ":" + seconds;
        }
    }
    public static void Finish()
    {
        finished=true;
    }
    public static void StartTimer()
    {
        finished=false;
    }
}
