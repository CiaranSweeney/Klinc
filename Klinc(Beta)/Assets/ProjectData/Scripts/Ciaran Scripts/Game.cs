using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//edited by Ciaran Sweeney 28/10
//edited by Ciaran Sweeney 1/11
//edited by Ciaran Sweeney 4/11
//edited by Ciaran Sweeney 5/11
public class Game : MonoBehaviour {

	// Use this for initialization
    public Card[] deck = new Card[51];
    public int numberOfPlayers=4;
    public Timer timer;
    public BluffOrPlayCard bluffOrPlayCard;
    public DrinkMeter drinkMeter;
    Table table;
    bool gameStarted = false;
    int handSize = 4;
    int roundNumber = 0;
    //This will be used to id the user
    int playerId = 3;
    //Current card of the round
    Card currentTableCard;
    ArrayList players=new ArrayList();
    // CardpositionArray is a Array of Vector2 Objects containing the X and Y poisiton of the Cards
     Vector2[] CardTablePositions = { 
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

    };
    //Postions for the hand
    Vector2[] handPositions = {
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


    void Start () {
       

    }
	
	// Update is called once per frame
	void Update () {
        if (!gameStarted) {
            StartGame();
            gameStarted = true;
         }

    }
    public void StartGame()
    {
        CardShuffle();

        for (int j = 0; j < numberOfPlayers; j++)
        {
            players.Add(new Player());
        }
        //dealing cards on the table
        table = new Table();

        //Adding cards to the table
        for (int j = 0; j < 16; j++)
        {
            //setting the cards face down
            deck[j].FaceDown();
            //bomber cards slots
            if (j == 3 || j == 5 || j == 9 || j == 15)
            {
                deck[j].SetBomberCardOnTable();
            }
            //adding the new postion to the card
            deck[j].SetPosition(CardTablePositions[j]);
            table.AddToTable(deck[j]);
        }

        //Dealing out the hand
        Player player;
        //count is for the card number in the deck. Its 16 because i already dealt 16 cards on the table
        int count = 16;
        //handPosistionIndex and bomberPosistionIndex are used for the array handPoistions
        int handPosistionIndex = 0;
        int bomberPosistionIndex = 0;
        //for the poker cards in the hand
        int playerCount = 0;
        for (int i = 0; i < handSize * numberOfPlayers; i++)
        {
            player = (Player)players[playerCount];
            //All other players cards a faceDown
            if (playerId != playerCount)
            {
                deck[count].HideCard();
            }
            //Sending the card to the player hand in the right position
            deck[count].SetPosition(handPositions[handPosistionIndex]);
            //Add it to the arrylist hand in Player class
            player.AddToHand(deck[count]);
            count++;
            handPosistionIndex++;
            playerCount++;
            //If the number is greater than the number of players fo back to the first player
            if (playerCount == numberOfPlayers)
                playerCount = 0;
        }

        //for the bomber cards in the hand
        playerCount = 0;
        
        for (int i = 0; i < handSize * numberOfPlayers; i++)
        {
            deck[count].SetBomberCard();
            player = (Player)players[playerCount];
            //Show the other players bomber cards
            if (playerId != playerCount)
            {
                deck[count].ShowCard();
            }
            deck[count].SetPosition(handPositions[bomberPosistionIndex]);
            //Add it to the arrylist bomberHand in Player class
            player.AddToBomberHand(deck[count]);
            count++;
            bomberPosistionIndex++;

            //If the number is greater than the number of players fo back to the first player
            playerCount++;
            if (playerCount == numberOfPlayers)
                playerCount = 0;
        }
    }

    //Code for shuffling the deck
    void CardShuffle()
    {
        Card temp;
        int random;
        for(int i=0; i<deck.Length; i++)
        {
            random = Random.Range(0, 51);
            temp = deck[random];
            deck[random] = deck[i];
            deck[i] = temp;
        }
    }
    public void Round()
    {
        roundNumber++;
        if (roundNumber >16)
        {
            return;
        }
        timer.SwitchTimerOnOff();
        //The -1 is used because of the index starts at 0 and round starts at 1
        currentTableCard = table.getTableCard(roundNumber-1);
        //Flip the current card
        currentTableCard.FaceUp();
        //Change the drinkmetter
        drinkMeter.DrinkLevel(roundNumber, currentTableCard);
        Card playerCard = null;
        Player p = (Player)players[playerId];
        if (currentTableCard.IsBomberCard())
            playerCard = p.SearchInBomberHand(currentTableCard);

        else
            playerCard = p.SearchInHand(currentTableCard);

        //This opens up the bluff/use card panel
        bluffOrPlayCard.BluffOrPlayCardScreen(playerCard);   
    }

    public void ShowPokerCards()
    {
        Player p = (Player)players[playerId];
        p.ShowPokerCards();
    }

    public void ShowBomberCards()
    {
        Player p = (Player)players[playerId];
        p.ShowBomberCards();
    }

}
