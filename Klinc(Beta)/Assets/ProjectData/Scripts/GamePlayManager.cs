using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
/// <summary>
/// Game play manager.
/// none of the Below used is currently effecting to us.
/// this class is used for the Photon Unity Network Connections.
/// </summary>
public class GamePlayManager : MonoBehaviour {
public static GamePlayManager instance;

	CardShuffleScript cd=new CardShuffleScript();
	public Text txt;
	int i=0;

	// Use this for initialization
	void Start () {
		instance = this; // Instance fo GamePlayManager
//		GlobalVariables.instance.getplayercards();
		print("Game Play Manager");
//		CardShuffleScript.instance.getplayercards ();
		}

	
	// Update is called once per frame
	void Update () {

		// Checking the No. of Players in the Room
		/*if (PhotonNetwork.playerList.Length == 2) 
			GamePlayManager.instance.GameTest(); // GameTest Method is called
*/
	}

	public void createRoom(string name)
	{
		NetworkManagerScript.instance.createRoom (name);
	}

	[PunRPC]
	public void GameTest(){
		if (PhotonNetwork.isMasterClient) {		
			txt.text = "Server";

			if (i == 0) {
				 		CardShuffleScript.instance.getplayercards ();
						
				i = 1;
				print ("Call Cards");
			}

		} else {
			txt.text = "Client";
		}


	}



}
