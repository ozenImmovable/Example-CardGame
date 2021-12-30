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
    
    //this function has not yet been edited but will be used for summonign allies                                                                                                     !!!!!!!!!!!!!!!!!
    public void Summon()
    {

        /* This function needs to check if the card is parented to the hand or is currently being dragged or the dropzone it is being dropped on has a sibling
         * if the card is not parent to the hand, is not being dragged, and has no siblings the ally can be summoned on the dropzone
         * If it is determined that the card can be summoned on the dropzone the card needs to be destroyed  after it is dropped and a new object needs to be spawned as a child of the dropzone
         * effects will need to be resolved based on if the card has any
         * APPLIES TO ALL TYPES: mana value for current mana will need to be decrimented
         * a seperate function may need to be called to determine which sprite is being spawned
         */

        //below is what this function originally did/does
        TurnSystem.currentMana -= cost;
        summoned = true;

        MaxMana(addXmaxMana);
        drawX = drawXcards;

    }

    public void Cast()
    {
        /* this function needs to check if it is hovering over a dropzone
         * It will also need to determine if the dropzone is an ally dropzone or an enemy based on which card it is
         * There is the possibility that a spell will target all characters, all allies, or all enemies, this needs to be accounted for usign the cards iD(?) or possibly a seperate function altogether
         * The basic function of the spell will probably need to be handled in sperate functions, IE drawing cards, dealing damage, etc..... 
         */
    }

    public void Modify()
    {
        /* This function uses many of the same actions as summoning
         * The difference to summoning is that this card does not care about the dropzone having children
         * this function will have to fire another function that determines what it does when played on a dropzone
         * temporarily this card will destroy itself and then a sprite will be added to that dropzone as a child and sibling to anything currently occupying it
         */
    }

    public void MaxMana(int x)
    {
        TurnSystem.maxMana += x;
    }
}
