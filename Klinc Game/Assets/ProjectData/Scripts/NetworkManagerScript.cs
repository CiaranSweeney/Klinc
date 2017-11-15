using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// THis Class is used for Multiplayer Support using PHOTON UNITY NETWORK.
/// This file is under developement so might may not find the Proper Comments
/// 
/// 
/// </summary>
public class NetworkManagerScript : Photon.PunBehaviour {



	public static NetworkManagerScript instance;

	public GameObject roomInfoPrefab;
	/// <summary>Connect automatically? If false you can set this to true later on or call ConnectUsingSettings in your own scripts.</summary>
	public bool AutoConnect = true;
	public byte Version = 4;

	/// <summary>if we don't want to connect in Start(), we have to "remember" if we called ConnectUsingSettings()</summary>
	private bool ConnectInUpdate = true; 
	RoomInfo[] roomList;

	public virtual void Start ()
	{	//GamePlayManager.instance.GameTest ();
		//GameObject.Find ("PlayerNameInput Field").GetComponent<UIInput> ().defaultText = GameManager.getPlayerName ();
		if (instance) {
			Destroy (gameObject);
			return;
		}
		DontDestroyOnLoad (gameObject);
		instance = this;
		PhotonNetwork.autoJoinLobby = true;    // we join randomly. always. no need to join a lobby to get the list of rooms.
		connectToPhoton("");

	}

	public void connectToPhoton (string playerName)
	{
		print ("Start");
//		PhotonNetwork.playerName = playerName;
		//GameManager.setPlayerName (playerName);
//		GameObject.Find ("ConnectingLabel").transform.position = new Vector2 (0, 0);
		if (!PhotonNetwork.connected) {
			print ("Connecting");
			PhotonNetwork.ConnectUsingSettings (Version + "." + Application.loadedLevel);
			PhotonNetwork.JoinRoom ("myRoom");
			createRoom ("room1");
		} else {
			print ("Connected");
		//	GamePlayManager.instance.GameTest ();
			//Application.LoadLevel ("MP_Room_OptionScene");
		}
	}

	public void createRoom (string name)
	{
		RoomOptions ro = new RoomOptions (){ maxPlayers = 2, isVisible = true };
		if (name.Length > 0) {
			print ("Join or Create");
			PhotonNetwork.JoinOrCreateRoom (name, ro, TypedLobby.Default);

		}
		//		PhotonNetwork.CreateRoom (name, true, true, 2);
	}

	public void showRoomList ()
	{
		roomList = new RoomInfo[0];
		if (roomList.Length == PhotonNetwork.GetRoomList ().Length)
			return;

		int count = GameObject.Find ("Grid").transform.childCount;
		for (int i = 0; i < count; i++)
			Destroy (GameObject.Find ("Grid").transform.GetChild (i).gameObject);


		//		print ("RoomListSize= " + PhotonNetwork.GetRoomList ().Length);
		roomList = PhotonNetwork.GetRoomList ();
		foreach (RoomInfo room in roomList) {
//			GameObject roomObject = NGUITools.AddChild (GameObject.Find ("Grid"), roomInfoPrefab);
//			roomObject.transform.FindChild ("RoomName").GetComponent<UILabel> ().text = room.name;/
//			if (room.isLocalClientInside)
//				roomObject.transform.FindChild ("JoinBtn").gameObject.SetActive (false);
//			else
//				roomObject.transform.FindChild ("JoinBtn").gameObject.name = room.name;
		}
//		GameObject.Find ("Grid").GetComponent<UIGrid> ().Reposition ();
	}

	public void OnJoinBtnClicked (GameObject roomName)
	{
		PhotonNetwork.JoinRoom (roomName.name);
	}

	public void leaveRoomMethod ()
	{
		PhotonNetwork.LeaveRoom ();
	}

	[PunRPC]
	public void showPlayersOnMyRoom ()
	{
		foreach (PhotonPlayer player in PhotonNetwork.playerList) {
			if (GameObject.Find ("Grid").transform.Find (player.name))
				continue;
		//	GameObject playerObject = NGUITools.AddChild (GameObject.Find ("Grid"), roomInfoPrefab);
		//	playerObject.name = player.name;
		//	playerObject.transform.FindChild ("RoomName").GetComponent<UILabel> ().text = player.name;
		//	playerObject.transform.FindChild ("JoinBtn").gameObject.SetActive (false);
		}
		if (PhotonNetwork.playerList.Length == 2) {
		//	GameManager.isPlayerSelected = true;
			GamePlayManager.instance.GameTest ();
			//Application.LoadLevel ("MP_GameScene");
		}
	//	GameObject.Find ("Grid").GetComponent<UIGrid> ().Reposition ();
	}

	// to react to events "connected" and (expected) error "failed to join random room", we implement some methods. PhotonNetworkingMessage lists all available methods!

	public virtual void OnConnectedToMaster ()
	{
		if (PhotonNetwork.networkingPeer.AvailableRegions != null)
			Debug.LogWarning ("List of available regions counts " + PhotonNetwork.networkingPeer.AvailableRegions.Count + ". First: " + PhotonNetwork.networkingPeer.AvailableRegions [0] + " \t Current Region: " + PhotonNetwork.networkingPeer.CloudRegion);
		Debug.Log ("OnConnectedToMaster() was called by PUN. Now this client is connected and could join a room. Calling: PhotonNetwork.JoinRandomRoom();");
		//				PhotonNetwork.JoinRandomRoom ();
	}

	public virtual void OnPhotonRandomJoinFailed ()
	{
		//		if (GameManager.isGameOver)
		//			return;
	//	GeneralFunctions.instance.StopCoroutine ("joinRandomRoom");
	//	GeneralFunctions.instance.loadLobbyScene ();
		Debug.Log ("OnPhotonRandomJoinFailed() was called by PUN. 	, so we create one. Calling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 4}, null);");
		//				PhotonNetwork.CreateRoom (null, new RoomOptions () { maxPlayers = 4 }, null);
	}

	// the following methods are implemented to give you some context. re-implement them as needed.

	public virtual void OnFailedToConnectToPhoton (DisconnectCause cause)
	{
	/*	#if UNITY_ANDROID
		AndroidDialog.Create ("Warning", "Photon can not connect ", "Okay", "Cancel");
		#elif UNITY_IPHONE
		IOSDialog.Create ("Warning", "Photon can not connect ", "Okay", "Cancel");
		#endif

		print ("Photon Can not connect becasue internet problem is occur");
		Debug.LogError ("Cause: " + cause);
		Application.LoadLevel ("HomeScene");

	*/
	}

	public virtual void OnPhotonPlayerDisconnected (PhotonPlayer otherPlayer)
	{
		Debug.Log ("Player Disconnected on any one side this method is called on both side..");
		//		if (otherPlayer.name.Equals (PhotonNetwork.playerName))
		//			print ("its current player.");
		//		else
	//	GeneralFunctions.instance.anotherPlayerLeft ();
	}

	public void OnJoinedRoom ()
	{
	//	if (GameManager.isGameOver)
//			return;
		Debug.Log ("OnJoinedRoom() called by PUN. Now this client is in a room. From here on, your game would be running. For reference, all callbacks are listed in enum: PhotonNetworkingMessage");
		if (PhotonNetwork.room.playerCount == 2)
			GamePlayManager.instance.GameTest ();
		//else
			
	}


	public void OnJoinedLobby ()
	{
//		if (GameObject.Find ("ConnectingLabel"))
// 			GameObject.Find ("ConnectingLabel").GetComponent<UILabel> ().text = "Connected";
		//		Application.LoadLevel ("MP_Room_OptionScene");
		if (PhotonNetwork.GetRoomList ().Length == 0) {
			StartCoroutine (checkForRoom ());
			GamePlayManager.instance.createRoom ("myRoom");
		} //else {
//			GeneralFunctions.instance.loadLobbyScene ();
//		}
		Debug.Log ("OnJoinedLobby(). Use a GUI to show existing rooms available in PhotonNetwork.GetRoomList().");
	}

	IEnumerator checkForRoom ()
	{
		yield return new WaitForSeconds (2);
		if (PhotonNetwork.GetRoomList ().Length == 0) {
			GamePlayManager.instance.createRoom ("myRoom");
		} else {
//			GeneralFunctions.instance.loadLobbyScene ();
		}
	}

}
