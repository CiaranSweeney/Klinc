using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class LeaderboardControler : MonoBehaviour {

	[SerializeField]GameObject EnteryPrefab;
	VerticalLayoutGroup VLG;
	RectTransform rTransform;
	ScrollRect sRect;
	float oldPoss = 0;
	float moveDelta = 0;
	public int NumOfEntriesToLoad = 12;

	LeadboardEntery[] BoardArray;

	void Awake(){
		VLG = gameObject.GetComponent<VerticalLayoutGroup>();
		rTransform = gameObject.GetComponent<RectTransform>();
		sRect = transform.parent.GetComponent<ScrollRect>();
		BoardArray = new LeadboardEntery[NumOfEntriesToLoad];
		for(int i=0;i < NumOfEntriesToLoad;i++){
			BoardArray[i] = AddEntryToTop();
		}

	}

	public void FixedUpdate(){
		rTransform.sizeDelta = new Vector2(505,VLG.minHeight);
	}

	public LeadboardEntery AddEnteryToBotom(){
		GameObject temp = Instantiate(EnteryPrefab,this.transform);
		return temp.GetComponent<LeadboardEntery>();
	}
	public LeadboardEntery AddEntryToTop(){
		GameObject temp = Instantiate(EnteryPrefab,this.transform);
		temp.transform.SetAsFirstSibling();
		return temp.GetComponent<LeadboardEntery>();
	}

	public void WhenScroling(){
		moveDelta += rTransform.position.y-oldPoss;
		oldPoss = rTransform.position.y;
		if(moveDelta > 71){
			moveDelta = 0;
		}else if(moveDelta < 72){
			moveDelta = 0;
		}
		Debug.Log(rTransform.position.y);
	}
}
