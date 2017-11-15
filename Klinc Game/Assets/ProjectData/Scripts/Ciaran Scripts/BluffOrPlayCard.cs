using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
//Made by Ciaran Sweeney on 05/11/2017
public class BluffOrPlayCard : MonoBehaviour {

    // Use this for initialization
    //public Canvas canvas;
    //public GameObject panelbluffOrPlayCard;
    public GameObject bluffButton;
    public GameObject noBluffButton;
    public GameObject playCardButton;
    public GameObject dontPlayCardButton;
    public Timer timer;
    Card card=null;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BluffOrPlayCardScreen(Card playerCard)
    {
        gameObject.SetActive(true);
        if (playerCard != null)
        {
            card = playerCard;
            playCardButton.SetActive(true);
            dontPlayCardButton.SetActive(true);
        }
        else
        {
            bluffButton.SetActive(true);
            noBluffButton.SetActive(true);
        }
    }

    public void GetRidOfBluffOrPlayCardScreen()
    {
        gameObject.SetActive(false);
        card = null;
        playCardButton.SetActive(false);
        dontPlayCardButton.SetActive(false);
        bluffButton.SetActive(false);
        noBluffButton.SetActive(false);
        timer.SwitchTimerOnOff();
    }

    public void PlayCard()
    {
        GetRidOfBluffOrPlayCardScreen();
    }
}
