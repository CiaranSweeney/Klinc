using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//edited by Ciaran Sweeny 28/10
//edited by Ciaran Sweeny 1/11
public class Table : MonoBehaviour {

    // Use this for initialization
    ArrayList tableCards = new ArrayList();
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddToTable(Card card)
    {
        tableCards.Add(card);
    }

    

    public Card getTableCard(int n)
    {
        return (Card)tableCards[n];
    }

}
