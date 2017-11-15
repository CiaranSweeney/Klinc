using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Made by Ciaran Sweeney on 22/10/2017
public class DrinkMeter : MonoBehaviour {

    // Use this for initialization
    public Text turnText;
    public Text drinkLevelText;


    int drinkLevel=0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DrinkLevel(int turn,Card card)
    {
        // If the card is a bomber card then the drink meter is equal to the value of the card
        if (card.IsBomberCard())
        {
            turnText.text = "Turn Count: " + turn;
            drinkLevelText.text = "Drink Level: " + card.GetCardValue();
            return;
        }
        drinkLevel = turn;
        if (drinkLevel != 0)
        {
            //The int will round down which is what I want
            //This calculation will determine if the drinks will go up a level
            int workingOutDrinkLevel = (turn-1) / 4;
            drinkLevel = workingOutDrinkLevel;
        }
        //I put this in for a calulation reason so the drink level is correct
        drinkLevel++;
        //Updating the text on the UI to match the changes
        turnText.text = "Turn Count: "+turn;
        drinkLevelText.text = "Drink Level: " + drinkLevel;
    }


}
