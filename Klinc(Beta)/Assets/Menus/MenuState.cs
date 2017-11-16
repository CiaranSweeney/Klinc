using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum emenus {Login,CreateAccount,Main,Store,Inventory,Leaderboard,Freinds,Account,Instructions,Settings,NumberOfTypes};
public enum epopUps {HealthWarning,TermsAndConditions,GoGold,NumberOfTypes};

public class MenuState : MonoBehaviour {

	public Image background;
	public GameObject Burger;
	public GameObject[] menu = new GameObject[(int)emenus.NumberOfTypes];
	public GameObject[] popUps = new GameObject[(int)epopUps.NumberOfTypes];

	public int moveDistance;

	public void Start(){
		moveDistance = (int)Burger.gameObject.GetComponent<RectTransform>().rect.width;
		setState("Login");
	}
		
	//menu controls
	public void setState(string s){
		emenus st = (emenus)System.Enum.Parse(typeof(emenus),s);

		CloseAll();
		menu[(int) st].SetActive(true);

	}
	void CloseAll(){
		foreach(GameObject go in menu){
			go.SetActive(false);
		}
		MoveBurgerOutOfView();
	}

	//popup controls
	public void PopPopUp(string s){
		epopUps st = (epopUps)System.Enum.Parse(typeof(epopUps),s);

		popUps[(int) st].SetActive(true);
	}
	public void ClosePopUp(string s){
		epopUps st = (epopUps)System.Enum.Parse(typeof(epopUps),s);

		popUps[(int) st].SetActive(false);
	}

	//burger controls
	public void MoveBurgerToInView(){
		Burger.transform.position = new Vector3(0,1024,0);
	}
	public void MoveBurgerOutOfView(){
		Debug.Log("asdfa");
		Burger.transform.position = new Vector3(-moveDistance,1024,0);
	}

}
