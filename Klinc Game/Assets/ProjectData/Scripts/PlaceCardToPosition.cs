using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Place card to position.
/// THis class is called when BomberCard or PokerCard Prefabs are Created
/// </summary>
public class PlaceCardToPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
	//	print (Screen.width);
		if(gameObject.name=="3"||gameObject.name=="5"||gameObject.name=="9"||gameObject.name=="15")
		transform.Rotate (0, 0, 90);	

		if (GlobalVariables.players == 4) {

			if (gameObject.name == "18" || gameObject.name == "22" || gameObject.name == "26" || gameObject.name == "30" || gameObject.name == "34" || gameObject.name == "38" || gameObject.name == "42" || gameObject.name == "46"  )
			//	transform.Rotate (0, 180, 90);	
			transform.Rotate (0, 0, 90);	
			if (gameObject.name == "16" || gameObject.name == "20" || gameObject.name == "24" || gameObject.name == "28" || gameObject.name == "32" || gameObject.name == "36" || gameObject.name == "40" || gameObject.name == "44"  )
				//transform.Rotate (180, 0, 90);
				transform.Rotate (0, 0, 90);	
		}
		if (GlobalVariables.players == 3) {


			if (gameObject.name == "18" || gameObject.name == "22" || gameObject.name == "26" || gameObject.name == "30" || gameObject.name == "34" || gameObject.name == "38" || gameObject.name == "42" || gameObject.name == "46"  )
				//transform.Rotate (0, 180, 90);	
				transform.Rotate (0, 0, 90);	
		}
		float LocationX = GlobalVariables.CardPositionArray [GlobalVariables.CardArrayIndex].x;
		float LocationY = GlobalVariables.CardPositionArray [GlobalVariables.CardArrayIndex].y;
		Vector2 PerfectLocation = GlobalVariables.CardPositionArray [GlobalVariables.CardArrayIndex];
	//GlobalVariables globalVariableObject = gameObject.AddComponent(typeof(GlobalVariables)) as GlobalVariables; // Creating the Object of GlobalVariables.cs
		if (Screen.width == 1280) {
			LocationX =(float) (LocationX / 1.5);
			LocationY =(float) (LocationY/1.5);
				PerfectLocation.x = LocationX;
				PerfectLocation.y = LocationY;
			RectTransform rt = (RectTransform) gameObject.transform;
			rt.sizeDelta = new Vector2 (50f,80f);
		}
		LeanTween.move (gameObject, PerfectLocation, 1f); // LeanTween Animation Plugin for Unity is used for the Animation Purpsoe of moving the card from one place to in hand of other players.
	}

}
