using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Ciaran Sweeney 12/10/2017
//edited by Peter Major 21/10
//edited by Ciaran Sweeny 28/10
//edited by Ciaran Sweeny 1/11
public class Card : MonoBehaviour {

    // Use this for initialization
	[SerializeField]int cardValue;
    public Vector2 cardPoistion;
    public Sprite cardBack;
    public Sprite bomberCardback;
    public Sprite cardFace;
    public Image cardImage;

    bool bomberCard = false;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
        //cardFace = this.gameObject.GetComponent<SpriteRenderer>().sprite;
        cardImage = GetComponent<Image>();
        cardFace = cardImage.sprite;
    }
   
    public void SetBomberCard()
    {
        bomberCard = true;
        gameObject.SetActive(false);
    }
    public void SetBomberCardOnTable()
    {
        bomberCard = true;
        cardImage.sprite = bomberCardback;
        transform.Rotate(0, 0, 90);
    }
    
    public bool IsBomberCard()
    {
        return bomberCard;
    }

    public void SetPosition(Vector2 pos)
    {
        cardPoistion = pos;
        transform.position = cardPoistion;
    }
    public int GetCardValue()
    {
        return cardValue;
    }

    public void FaceDown()
    {
        cardImage.sprite = cardBack;
    }

    public void FaceUp()
    {
        cardImage.sprite = cardFace;
        //sr.sprite = cardFace;
    }

    public void HideCard()
    {
        gameObject.SetActive(false);
    }

    public void ShowCard()
    {
        gameObject.SetActive(true);
    }
}
