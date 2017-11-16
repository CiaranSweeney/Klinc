using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeadboardEntery : MonoBehaviour {

	[SerializeField]Text place;
	[SerializeField]Text playerName;
	[SerializeField]Text drinksTaken;
	[SerializeField]Text drinksGiven;
	[SerializeField]Text ratio;

	public void SetEnteryData(int Place, string Name, int DrinksTaken, int DrinksGiven, int Ratio){
		place.text = "" +Place;
		playerName.text = Name;
		drinksTaken.text = "" + DrinksTaken;
		drinksGiven.text = "" + DrinksGiven;
		ratio.text = "" + ratio;
	}

}
