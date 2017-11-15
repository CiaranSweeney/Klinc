	using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Global variables.
/// used to Store the Global Variables
/// 
/// </summary>
public class GlobalVariables : MonoBehaviour {
	
	public static GlobalVariables instance;
	public static List<int> CardinUse = new List<int> ();
	int TotalNoOfCards;
	public static int players = 4; // No. of Player in Current Game
	public static int playerName = 3; // Player Name
	public static int CardArrayIndex=-1; // Index of Card Array
	public static Vector2[] CardPositionArray = { // CardpositionArray is a Array of Vector2 Objects containing the X and Y poisiton of the Cards
		//1st Row among 16 Cards
		new Vector2((float)772,(float) 344),
		new Vector2((float)908,(float) 344),
		new Vector2((float)1037,(float) 344),
		new Vector2((float)1164.1,(float) 345),
		//2nd Row among 16 Cards
		new Vector2((float)1164,(float) 477),
		new Vector2((float)1039,(float) 478),
		new Vector2((float)908,(float) 477),
		new Vector2((float)769.95,(float) 477),
		//3rd Row among 16 Cards
		new Vector2((float) 769.95,(float) 610),
		new Vector2((float) 906,(float) 606.7),
		new Vector2((float) 1034,(float) 610),
		new Vector2((float) 1160.3,(float) 610),
		//4th Row among 16 Cards
		new Vector2((float)1160.3,(float) 733.5),
		new Vector2((float)1034,(float) 733.5),
		new Vector2((float)909,(float) 733.5),
		new Vector2((float)767.5,(float) 738),



		//1st Card of all Players
		new Vector2((float)579,(float) 375.8),
		new Vector2((float)849.05,(float) 890),
		new Vector2((float)1355.3,(float) 716),
		new Vector2((float)1056,(float) 190),
		//2nd Card of all Players
		new Vector2((float)579,(float) 491.5),
		new Vector2((float)928.27,(float) 890),
		new Vector2((float)1355.3,(float) 601.5),
		new Vector2((float)960,(float) 190),
		// 3rd Card of all Players

		new Vector2((float)579,(float) 606),
		new Vector2((float)1007.3,(float) 890),
		new Vector2((float)1355.3,(float) 487),
		new Vector2((float)854,(float)187),
		// 4th Card of all Players

		new Vector2((float)579,(float) 720.5),
		new Vector2((float)1083.5,(float) 890),
		new Vector2((float)1355.3,(float) 372.5),
		new Vector2((float)759.1,(float) 190.1),




		//1st Card of all Players
		new Vector2((float)579,(float) 375.8),
		new Vector2((float)849.05,(float) 890),
		new Vector2((float)1355.3,(float) 716),
		new Vector2((float)1056,(float) 190),
		//2nd Card of all Players
		new Vector2((float)579,(float) 491.5),
		new Vector2((float)928.27,(float) 890),
		new Vector2((float)1355.3,(float) 601.5),
		new Vector2((float)960,(float) 190),
		// 3rd Card of all Players

		new Vector2((float)579,(float) 606),
		new Vector2((float)1007.3,(float) 890),
		new Vector2((float)1355.3,(float) 487),
		new Vector2((float)854,(float)187),
		// 4th Card of all Players

		new Vector2((float)579,(float) 720.5),
		new Vector2((float)1083.5,(float) 890),
		new Vector2((float)1355.3,(float) 372.5),
		new Vector2((float)759.1,(float) 190.1),
	

	};

	void Start()
	{
		instance = this;
//		getplayercards ();
	}

	void Update()
	{
		
	}







}
