using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Made by Ciaran Sweeny 1/11/2017
//edited by Ciaran Sweeny 5/11
public class Timer : MonoBehaviour {

    // Use this for initialization
    public Text timer;
    public BluffOrPlayCard bluffOrPlayCard;
    bool startTimer = false;
    float countDown = 30f;
    string currentTime;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (startTimer)
        {
            countDown -=Time.deltaTime;
            if (countDown<=0)
            {
                //This will get rid of the screen and also reset the timer since the SwitchTimerOnOff method is used in the GetRidOfBluffOrPlayCardScreen() method
                bluffOrPlayCard.GetRidOfBluffOrPlayCardScreen();
            }
            //F0 gets rid of the decimal places
            timer.text = countDown.ToString("F0");
        }
	}
    public void SwitchTimerOnOff()
    {
        countDown = 30f;
        timer.text = countDown.ToString("F0");
        startTimer = !(startTimer);
    }
}
