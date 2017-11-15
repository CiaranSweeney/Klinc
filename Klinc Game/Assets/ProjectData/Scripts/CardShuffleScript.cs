using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
/// <summary>
/// Card shuffle script.
/// This Class is used to manage All Functionality of Cards.
/// </summary>
/// Ciaran I added in a method that get called to increase the turn count
public class CardShuffleScript : MonoBehaviour {
	public static CardShuffleScript instance;

	public bool boolStartGame=false; 

	public GameObject NetworkManager;
	// no. of cards in use
	public static List<int> CardinUse = new List<int> ();
	
    // total Cards
	int TotalNoOfCards;

	// Text obj for Timer 
	public Text CounterTime;
	// timer
	float SecondCounter=-1;
//	public GameObject CardArray

// FlipButton GameObject is used for the referance of Flip Button in GUI
	public GameObject FlipButton;// card GameObject is used for the referance of PokerCard in GUI
	public GameObject card;// bombercard GameObject is used for the referance of BomberCard in GUI
	public GameObject bombercard;// Temp Object 
	GameObject cd;// Panel Object to keep the auto generated PREFABS in panel
	public Transform panel;// Image of Bomber Card
	public Sprite BomberCardImage;// Image of Poker Card
	public Sprite PokerCardImage;// Dummy Card image
	public Sprite CardImageDummy;// used to take the Referance fo the Object, But Right now We are not using it.
	GameObject CardToFlip; // Index to Access the LIST CardsOnTable.
	int CardToFlipIndex=-1;
	/// <summary>
	/// The card faces array.
	/// 2=2,3=3,.....,10=10,11=J,12=Q,13=K,14=A.
	///
	/// Spade
	/// club
	/// Diamond
	/// Heart
	/// 
	/// 
	/// </summary>
	public Sprite[] CardFacesArray = {};

	List<GameObject> CardsOnTable = new List<GameObject> (); // List to Store the Object of the Prefabs.
	float timeToReachTarget;// Testing Purpose
	float timeLeft = 6f;// Time to Complete the Card Shuffle 



	int index = 48;// Maimum Index of possible card in hand of the users
	int scard=1;
// Used as a Index

	float t,i=300;// t for Time and i for the Fliping Process.

    //This is used to increase the drink meter and what turn you are on
    //public DrinkMeter drinkMeter;


	// Use this for initialization
	void Start () {				
		instance = this;




		getplayercards ();

		//print(CardinUse [5]);
		if (GlobalVariables.players == 4) {
			timeLeft = (float)6.25f;
		} else if (GlobalVariables.players == 3) {
			timeLeft = 5.25f;
		}
		else if (GlobalVariables.players == 3) {
			timeLeft = 4.25f;
		}

	}

	// Update is called once per frame
	void Update () {



	



/// Counter
		/// 
		if (!boolStartGame) {
			return;
		}

		if ((int)SecondCounter == 0) {
			SecondCounter = -1;
			Flipcard (null);
            //Ciaran "I added moving to the next turn here "
            //drinkMeter.nextTurn();

        } else {
			if(SecondCounter>=0)
				SecondCounter -= Time.deltaTime;
			CounterTime.text = ((int)SecondCounter).ToString();
		}

		///<summary>
		/// Code to Flip the Cards
		/// </summary>
		if (i < 245) {
			//SecondCounter = 30;
		//	print ("Fliping"); // teSTING purpose
			i = i + (180 * Time.deltaTime);

			
		/*	if(CardToFlipIndex==3 ||CardToFlipIndex==5||CardToFlipIndex==9||CardToFlipIndex==15) // Flip of Bomber Card
				CardsOnTable [CardToFlipIndex].transform.Rotate (i * Time.deltaTime, 0,90);
			else */
				CardsOnTable [CardToFlipIndex].transform.Rotate (0, i * Time.deltaTime, 0); // Flip of Poker Card

			if (i > 170) {
				CardImageDummy = CardFacesArray [CardinUse[CardToFlipIndex]];
				CardsOnTable [CardToFlipIndex].GetComponent<UnityEngine.UI.Image> ().sprite = CardImageDummy;
			
			}


		} else {
			FlipButton.SetActive (true);
			
		}





///<summary>
		/// Card Distribution Code
		/// </summary>





		t += Time.deltaTime / timeToReachTarget;
// This is used as a Loop for Given time "timeLeft";
		timeLeft -= Time.deltaTime;

		if (timeLeft < 0) {

		} else {



			scard++;	
			int newindex = (int)(timeLeft / 0.125);
				// is the new card and Current Card index is same ?
			if (newindex == index) {
// Yes Do Nothing
			} else {


// no

				// Accessing CardArrayIndex variable form GlobalVariables.cs
				GlobalVariables.CardArrayIndex++;
// First 16 Cards are distributed as that cards are not defect in any no. of Players
				if (GlobalVariables.CardArrayIndex > 15) {
					// if There are three Players skip the Below Listed Index of the Array
					if (GlobalVariables.players == 3 && (GlobalVariables.CardArrayIndex == 16 || GlobalVariables.CardArrayIndex == 20 || GlobalVariables.CardArrayIndex == 24 || GlobalVariables.CardArrayIndex == 28 || GlobalVariables.CardArrayIndex == 32 || GlobalVariables.CardArrayIndex == 36 || GlobalVariables.CardArrayIndex == 40 || GlobalVariables.CardArrayIndex == 44)) {
						GlobalVariables.CardArrayIndex++;
					}
	// if There are only two Players skip the Below Listed Index of the Array
					if (GlobalVariables.players == 2 && (GlobalVariables.CardArrayIndex == 16 || GlobalVariables.CardArrayIndex == 20 || GlobalVariables.CardArrayIndex == 24 || GlobalVariables.CardArrayIndex == 28 || GlobalVariables.CardArrayIndex == 32 || GlobalVariables.CardArrayIndex == 36 || GlobalVariables.CardArrayIndex == 40 || GlobalVariables.CardArrayIndex== 44 || GlobalVariables.CardArrayIndex== 18 || GlobalVariables.CardArrayIndex == 22 || GlobalVariables.CardArrayIndex== 26 || GlobalVariables.CardArrayIndex== 30 || GlobalVariables.CardArrayIndex== 34 || GlobalVariables.CardArrayIndex== 38 || GlobalVariables.CardArrayIndex== 42 || GlobalVariables.CardArrayIndex== 46)) {
						GlobalVariables.CardArrayIndex++;
					}
				}
// Creating Bomber Cards
				// at Index 3,5,9,15;
				if (GlobalVariables.CardArrayIndex == 3 || GlobalVariables.CardArrayIndex == 5 || GlobalVariables.CardArrayIndex == 9|| GlobalVariables.CardArrayIndex== 15) {
					cd=	Instantiate (bombercard, transform.position, transform.rotation);// Creating an Object from Prefab of Bomber Card.
					cd.name = GlobalVariables.CardArrayIndex.ToString();// Assigning Name to The Object.
					cd.transform.SetParent (panel.transform, false); //Placing the Object in Panel Area.
				//	print ("bomber");

				} else {
					cd=	Instantiate (card, transform.position, transform.rotation);// Creating an Object from Prefab of Bomber Card.
					cd.name = GlobalVariables.CardArrayIndex.ToString();// Assigning Name to The Object.
					cd.transform.SetParent (panel.transform, false); //Placing the Object in Panel Area.
				//	print ("Poker : "+index+" Scard : "+scard);

					if (CardsOnTable.Count > 15+(GlobalVariables.players*4)) {
						
						CardImageDummy = CardFacesArray [CardinUse [CardsOnTable.Count]];
					//	CardImageDummy = CardFacesArray [42];
						if (CardsOnTable.Count > 15) {
							cd.transform.Rotate (0, 180,0);
						}
						cd.GetComponent<UnityEngine.UI.Image> ().sprite = CardImageDummy;
				//		print ("bomberyu");
					}

				}
				index = newindex;
				CardsOnTable.Add (cd);

			}
		}


	}


	/// <summary>
	/// Pokers to bomber.
	/// used to see the Bomber card of ourself, Called from the GUI.
	/// 
	/// </summary>
	/// <param name="str">String.</param>

	public void PokerToBomber(string str)
	{ // Cards Need to be changed when 4 Players are Playing
	if (GlobalVariables.players == 4) {

			CardsOnTable [19].SetActive (false);
			CardsOnTable [23].SetActive (false);
			CardsOnTable [27].SetActive (false);
			CardsOnTable [31].SetActive (false);

			CardsOnTable [35].SetActive (true);
			CardsOnTable [39].SetActive (true);
			CardsOnTable [43].SetActive (true);
			CardsOnTable [47].SetActive (true);
			/*
			CardsOnTable [19].GetComponent<Image> ().sprite = CardImageDummy;
			CardsOnTable [23].GetComponent<Image> ().sprite = CardImageDummy;
			CardsOnTable [27].GetComponent<Image> ().sprite = CardImageDummy;
			CardsOnTable [31].GetComponent<Image> ().sprite = CardImageDummy;
			*/
		}
		// Cards Need to be changed when 3 Players are Playing
		if (GlobalVariables.players == 3) {

			CardsOnTable [18].SetActive (false);
			CardsOnTable [21].SetActive (false);
			CardsOnTable [24].SetActive (false);
			CardsOnTable [27].SetActive (false);

			CardsOnTable [30].SetActive (true);
			CardsOnTable [33].SetActive (true);
			CardsOnTable [36].SetActive (true);
			CardsOnTable [39].SetActive (true);


			/*
			CardsOnTable [18].GetComponent<Image> ().sprite = BomberCardImage;
			CardsOnTable [21].GetComponent<Image> ().sprite = BomberCardImage;
			CardsOnTable [24].GetComponent<Image> ().sprite = BomberCardImage;
			CardsOnTable [27].GetComponent<Image> ().sprite = BomberCardImage;
			*/
		}
// Cards Need to be changed when 2 Players are Playing
		if (GlobalVariables.players == 2) {
			
			CardsOnTable [17].SetActive (false);
			CardsOnTable [19].SetActive (false);
			CardsOnTable [21].SetActive (false);
			CardsOnTable [23].SetActive (false);

			CardsOnTable [25].SetActive (true);
			CardsOnTable [27].SetActive (true);
			CardsOnTable [29].SetActive (true);
			CardsOnTable [31].SetActive (true);
			/*
			CardsOnTable [17].GetComponent<Image> ().sprite = BomberCardImage;
			CardsOnTable [19].GetComponent<Image> ().sprite = BomberCardImage;
			CardsOnTable [21].GetComponent<Image> ().sprite = BomberCardImage;
			CardsOnTable [23].GetComponent<Image> ().sprite = BomberCardImage;
			*/
		}
	}

	public void BomberToPoker(string str)
	{
		// Cards Need to be changed when 4 Players are Playing 
		if (GlobalVariables.players == 4) {

			CardsOnTable [19].SetActive (true);
			CardsOnTable [23].SetActive (true);
			CardsOnTable [27].SetActive (true);
			CardsOnTable [31].SetActive (true);

			CardsOnTable [35].SetActive (false);
			CardsOnTable [39].SetActive (false);
			CardsOnTable [43].SetActive (false);
			CardsOnTable [47].SetActive (false);

			CardsOnTable [19].GetComponent<Image> ().sprite = CardFacesArray[19];
			CardsOnTable [23].GetComponent<Image> ().sprite = CardFacesArray[23];
			CardsOnTable [27].GetComponent<Image> ().sprite = CardFacesArray[27];
			CardsOnTable [31].GetComponent<Image> ().sprite = CardFacesArray[31];

		}
		// Cards Need to be changed when 3 Players are Playing 
		if (GlobalVariables.players == 3) {
			CardsOnTable [18].SetActive (true);
			CardsOnTable [21].SetActive (true);
			CardsOnTable [24].SetActive (true);
			CardsOnTable [27].SetActive (true);

			CardsOnTable [30].SetActive (false);
			CardsOnTable [33].SetActive (false);
			CardsOnTable [36].SetActive (false);
			CardsOnTable [39].SetActive (false);

			CardsOnTable [30].GetComponent<Image> ().sprite = CardFacesArray[30];
			CardsOnTable [33].GetComponent<Image> ().sprite = CardFacesArray[33];
			CardsOnTable [36].GetComponent<Image> ().sprite = CardFacesArray[36];
			CardsOnTable [39].GetComponent<Image> ().sprite = CardFacesArray[39];


		}
		// Cards Need to be changed when 2 Players are Playing 

		if (GlobalVariables.players == 2) {
			CardsOnTable [17].SetActive (true);
			CardsOnTable [19].SetActive (true);
			CardsOnTable [21].SetActive (true);
			CardsOnTable [23].SetActive (true);

			CardsOnTable [25].SetActive (false);
			CardsOnTable [27].SetActive (false);
			CardsOnTable [29].SetActive (false);
			CardsOnTable [31].SetActive (false);

			CardsOnTable [17].GetComponent<Image> ().sprite = CardFacesArray[17];
			CardsOnTable [19].GetComponent<Image> ().sprite = CardFacesArray[19];
			CardsOnTable [21].GetComponent<Image> ().sprite = CardFacesArray[21];
			CardsOnTable [23].GetComponent<Image> ().sprite = CardFacesArray[23];

		}



	}
/// <summary>
	/// Flipcard the specified str.
	/// it called to filp the card from the GUI
	/// it is used to filp the card
	/// </summary>
	/// 

	public void Flipcard(string str)
	{   
		FlipButton.SetActive (false);
		i = 0;
		CardToFlipIndex++;
		SecondCounter = 30;
        //Inceasing the Turn counts
        //drinkMeter.nextTurn();
	}

	public void getplayercards()
	{
		//print ("Card Destribution");
		TotalNoOfCards = (GlobalVariables.players * 8) + 16;
		int i=0;
		while (i < TotalNoOfCards) {
			int j= Random.Range (0, 52);
			if(!CardinUse.Contains(j))
			{
				CardinUse.Add (j);
			//	Debug.Log("New card :"+j+" Index : "+i);
				i++;
			}
		}

		boolStartGame = true;
		GenerateCards();
	}

	public void GenerateCards ()// this will assign card properties to all cards for all players even if they are not playing
	{
		this.GetComponent<PhotonView> ().RPC ("ShareGeneratedCardsData", PhotonTargets.All,CardinUse);

		print(this.name);
	}


	/*
	[PunRPC] void ShareGeneratedCardsData (int[] masterCardsIntTemp)
	{
		for (int i = 0; i < masterCardsIntTemp.Length; i++) {
			
			CardsOnTable[i].GetComponent<Image>().sprite=CardFacesArray[i];
			if (!PhotonNetwork.isMasterClient) {
				boolStartGame = true;
			}
		}
	}
*/
	[PunRPC] void ShareGeneratedCardsData (List<int> masterCardsIntTemp)
	{
	//	for (int i = 0; i < masterCardsIntTemp.Count; i++)
			print ("funtion");
	//		if (!PhotonNetwork.isMasterClient)
	//			boolStartGame = true;
	

	}

}
