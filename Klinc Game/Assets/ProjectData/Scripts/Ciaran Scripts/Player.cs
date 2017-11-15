using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//edited by Ciaran Sweeny 28/10
//edited by Ciaran Sweeny 5/11
public class Player : MonoBehaviour {

    // Use this for initialization
    string name;
    int id;
    ArrayList hand = new ArrayList();
    ArrayList bomberHand = new ArrayList();

    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void AddToHand(Card card)
    {
        hand.Add(card);
    }

    public void AddToBomberHand(Card card)
    {
        bomberHand.Add(card);
    }

    //Search the Bhand
    public Card SearchInHand(Card tableCard)
    {
        return SeachForCard(hand, tableCard);

    }

    //Search the Bommber hand
    public Card SearchInBomberHand(Card tableCard)
    {
        return SeachForCard(bomberHand, tableCard);

    }

    //This method used for searching for cards with the same value
    Card SeachForCard(ArrayList cards,Card tableCard)
    {
        foreach (Card card in cards)
        {
            if (card.GetCardValue() == tableCard.GetCardValue())
                return card;
        }
        return null;
    }
    //Change from poker card to bomber cards
    public void ShowPokerCards()
    {
        foreach (Card c in bomberHand)
            c.HideCard();
        foreach (Card c in hand)
            c.ShowCard();
    }

    //Change from bomber card to poker cards
    public void ShowBomberCards()
    {
        foreach (Card c in hand)
            c.HideCard();
        foreach (Card c in bomberHand)
            c.ShowCard();
    }
}
