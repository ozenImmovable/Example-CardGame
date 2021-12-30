using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ThisCard : MonoBehaviour
{
    public List<Card> thisCard = new List<Card>();
    public int thisId;

    public int id;
    public string cardName;
    public int cost;
    public int power;
    public string cardDescription;

    public Text nameText;
    public Text costText;
    public Text powerText;
    public Text descriptionText;

    public Sprite thisSprite;
    public Image thatImage;
    //public Image frame; Only if  I want to change the frame color (Tutorial #04)
    public bool cardBack;
    //public static bool staticCardBack; //removed due to card linking
    
    CardBack CardBackScript;
    
    public GameObject Hand;
    public int numberOfCardsInDeck;

    //card summoning conditional variables and parameters initialization
    public bool canBeSummon;
    public bool summoned;
    public GameObject battleZone;

    //trying to solve a null objectr reference for the call to Turnsystem.currentMana
    public GameObject turnobject;
    //Solved...need to review, forgot how

        public static int drawX;
        public int drawXcards;
        public int addXmaxMana;


    //public GameObject TurnObject;

    //cardtype storage variable
    public string cardType;
    
    // Start is called before the first frame update
    void Start()
    {
        CardBackScript = GetComponent<CardBack>(); //part of the cardback linking solution
        thisCard[0] = CardDataBase.cardList[thisId];
        
        numberOfCardsInDeck = PlayerDeck.deckSize;

        canBeSummon = false;
        summoned = false;

        drawX = 0;
    }

    // Update is called once per frame
    void Update()
    {
       

        Hand = GameObject.Find("Hand Panel");
        if (this.transform.parent == Hand.transform.parent)
        {
            cardBack = false;
        }
        
        id = thisCard[0].id;
        cardName = thisCard[0].cardName;
        cost = thisCard[0].cost;
        power = thisCard[0].power;
        cardDescription = thisCard[0].cardDescription;

        thisSprite = thisCard[0].thisImage;

        drawXcards = thisCard[0].drawXcards;
        addXmaxMana = thisCard[0].addXmaxMana;

        nameText.text = "" + cardName;
        costText.text = "" + cost;
        powerText.text = "" + power;
        descriptionText.text = "" + cardDescription;

        //cardtype initializing and storage, case might go here

        //need to populate conditionally based off card id and type?
        //maybe just off card id?
        //is it even necessary to have multiple databases?


        cardType = thisCard[0].cardType;                            /////////////////////////////
        

        thatImage.sprite = thisSprite;

        //staticCardBack = cardBack; //removed due to card linking
        CardBackScript.UpdateCard(cardBack);
        
        if(this.tag == "Clone")
        {
            thisCard[0] = PlayerDeck.staticDeck[numberOfCardsInDeck - 1];
            numberOfCardsInDeck -= 1;
            PlayerDeck.deckSize -= 1;
            cardBack = false;
            this.tag = "Untagged";
        }

    //Conditional: cards can not be played if you dont have enough mana
        if (TurnSystem.currentMana >= cost && summoned == false)
        {
            canBeSummon = true;
        }
        else
        {
            canBeSummon = false;
        }

        //Conditional: cards are draggable if you have enough mana to play them
        if (canBeSummon == true)
        {
            gameObject.GetComponent<Draggable>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Draggable>().enabled = false;
        }

        battleZone = GameObject.Find("Dropzone");
        //TurnObject = GameObject.Find("TurnSystem");
        //Conditional: calls the SUMMON function if a card has been dragged onto the dropzone gameobject
        if(summoned == false && this.transform.parent == battleZone.transform)
        {
            Summon();
        }
       

    }
    
    public void Summon()
    {
        TurnSystem.currentMana -= cost;
        summoned = true;

        MaxMana(addXmaxMana);
        drawX = drawXcards;

    }

    public void MaxMana(int x)
    {
        TurnSystem.maxMana += x;
    }
}
