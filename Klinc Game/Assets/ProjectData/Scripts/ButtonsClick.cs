using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/// <summary>
/// Buttons click.
/// This class is used to Create Functions Called on an Event.
/// </summary>

public class ButtonsClick : MonoBehaviour {

	// numPlayer is a variable used to Store the No. Entered By the User.
	int numPlayer;

	//This Function is used to Move From Login Scene to Player Scene
	public void LoginToNumberOfPlayer(string change)
	{
		// to move From Login page to Number Of player screen
		SceneManager.LoadScene("Player"); 

	}
	//This Function is used to Move From Player Scene to MainScene
	public void NumberOfPlayerTOMain(string change)
	{

		// to move on MainScene
	
		SceneManager.LoadScene("MainScene"); 


	}

	// Function used to Get the No. of Player the TextBox
	public void GetInput(string choosePlayer) 
	{
		//converting string to integer value
		int.TryParse (choosePlayer, out numPlayer); 
		//integer number is Assigned to player variable of GlobalVariables.cs 
		GlobalVariables.players = numPlayer; 
	}
}
