using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public float temps = 120;
    [HideInInspector]
    public float CurrentTemps;
    //[HideInInspector]
    public float TimePerc;
    public Text timerText;
    public float tempsSec;
    public float tempsMs;
    
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){

        timerText.text = "Time : " + System.Math.Round(temps - CurrentTemps, 2).ToString("F");

        CurrentTemps += Time.deltaTime;
        if ((temps - CurrentTemps) <= 10)
            timerText.color = new Color32(50, 205, 50, 255);

        TimePerc = CurrentTemps / temps;
    }
}
