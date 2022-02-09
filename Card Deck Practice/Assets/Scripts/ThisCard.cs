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

    public bool canBeTarget;

    public GameObject turnobject;


    public static int drawX;
    public int drawXcards;
    public int addXmaxMana;


    //public GameObject TurnObject;

    //cardtype storage variable
    public string cardType;

    //Graveyard initialization and card destroying variables
    public bool canBeDestroyed;
    public GameObject DiscardZone;
    public bool beInDiscardZone;

    //initialization variables for playing cards////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public GameObject Target;
    public GameObject PlayZone1;
    public GameObject PlayZone2;
    public GameObject PlayZone3;
    public GameObject PlayZone4;
    public GameObject PlayZoneBorder;
    public int PlayZoneTargetNum;

    public static bool staticTargeting;
    public static bool staticTargetingPlayZone1;
    public static bool staticTargetingPlayZone2;
    public static bool staticTargetingPlayZone3;
    public static bool staticTargetingPlayZone4;

    public bool targeting;
    public bool targetingPlayZone;

    //not sure if below variable is needed
    public bool onlyThisCardPlay;

    public GameObject summonBorder;


    // Start is called before the first frame update
    void Start()
    {
        CardBackScript = GetComponent<CardBack>(); //part of the cardback linking solution
        thisCard[0] = CardDataBase.cardList[thisId];

        numberOfCardsInDeck = PlayerDeck.deckSize;

        canBeSummon = false;
        canBeTarget = false;
        summoned = false;

        drawX = 0;

        targeting = false;
        targetingPlayZone = false;


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

        if (this.tag == "Clone")
        {
            thisCard[0] = PlayerDeck.staticDeck[numberOfCardsInDeck - 1];
            numberOfCardsInDeck -= 1;
            PlayerDeck.deckSize -= 1;
            cardBack = false;
            this.tag = "Untagged";
        }

        //Conditional: cards can not be played if you dont have enough mana
        if (TurnSystem.currentMana >= cost && summoned == false && beInDiscardZone == false)
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
        if (summoned == false && this.transform.parent == battleZone.transform)
        {
            Summon();
        }

        //NEW: switch statement

        //copied if statement from directly above in order to check if the card is being moved around from the hand zone to somewhre else
        //if (summoned == false && modified== false && casted == false && this.transform.parent == battleZone.transform)
        //{
        //    Summon();
        //}

        //maybe use arguments to tell which card it is by its ID? is that redundant, discussion required
        //switch (cardType)
        //{
        //    case "ally":
        //        Debug.Log("ENTERED ALLY CASE");
        //        if (summoned == true && Input.GetMouseButtonUp(0))
        //        {
        //            Destroy();
        //        }
        //        break;
        //    case "material":
        //        Debug.Log("ENTERED MATERIAL CASE");
        //        break;
        //    case "spell":
        //        Debug.Log("ENTERED SPELL CASE");
        //        break;

        //}
        targeting = staticTargeting;

        if (staticTargetingPlayZone1 == true)
        {
            targetingPlayZone = staticTargetingPlayZone1;
            Target = GameObject.Find("PlayZone1");

        } else if (staticTargetingPlayZone2 == true) 
        {
            targetingPlayZone = staticTargetingPlayZone2;
            Target = GameObject.Find("PlayZone2");

        } else if (staticTargetingPlayZone3 == true)
        {
            targetingPlayZone = staticTargetingPlayZone3;
            Target = GameObject.Find("PlayZone3");

        } else if (staticTargetingPlayZone4 == true)
        {
            targetingPlayZone = staticTargetingPlayZone4;
            Target = GameObject.Find("PlayZone4");
        } else
        {
            Target = null;
        }

        

        //determines if the cards target is a playzone
        //if (targetingPlayZone == true)
        //{
        //    Target = PlayZone;
        //} else
        //{
        //    Target = null;
        //}

        //determines if the summoning border is active------------------------------------------------------------------------------------------------
        if (canBeSummon == true)
        {
            summonBorder.SetActive(true);
        } else
        {
            summonBorder.SetActive(false);
        }

        //this allows the card to be played from the Dropzone to a playzone
        if (targeting == true && targetingPlayZone == true && onlyThisCardPlay == true)
        {
            Play();
        }

        if (targeting == false && Target != null)
        {
            Destroy();
        }
    }

    //This function is what allows a card to be played from the dropzone to the playzone, it will eventually be replaced with the differnt types of card playing functions (summon/cast/modify)
    public void Play()
    {
        if (Target != null)
        {
            if (Target == PlayZone1)
            {
                //Destroy card and send to graveyard/reparent
                
                //targeting = false;
            }


        }
    }

    //this function has not yet been edited but will be used for summonign allies                                                                                                     !!!!!!!!!!!!!!!!!
    public void Summon()
    {

        /* This function needs to check if the card is parented to the hand or is currently being dragged or the dropzone it is being dropped on has a sibling
         * if the card is not parent to the hand, is not being dragged, and has no siblings the ally can be summoned on the dropzone
         * If it is determined that the card can be summoned on the dropzone the card needs to be destroyed  after it is dropped and a new object needs to be spawned as a child of the dropzone
         * effects will need to be resolved based on if the card has any effects
         * APPLIES TO ALL TYPES: mana value for current mana will need to be decrimented
         * a seperate function may need to be called to determine which sprite is being spawned
         */

        //below is what this function originally did/does
        TurnSystem.currentMana -= cost;
        summoned = true;
        canBeDestroyed = true;
        MaxMana(addXmaxMana);
        drawX = drawXcards;
        //Destroy();
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

    public void Destroy()
    {
        DiscardZone = GameObject.Find("Discard Panel");
        
        if (canBeDestroyed == true)
        {
            this.transform.SetParent(DiscardZone.transform);
            canBeDestroyed = false;
            summoned = false;
            beInDiscardZone = true;
        }
    }

    public void UntargetPlayZone()
    {

        staticTargetingPlayZone1 = false;
    }
    public void TargetPlayZone()
    {
        staticTargetingPlayZone1 = true;
    }
    public void UntargetPlayZone2()
    {
        staticTargetingPlayZone2 = false;
    }
    public void TargetPlayZone2()
    {
        staticTargetingPlayZone2 = true;
    }
    public void UntargetPlayZone3()
    {
        staticTargetingPlayZone3 = false;
    }
    public void TargetPlayZone3()
    {
        staticTargetingPlayZone3 = true;
    }
    public void UntargetPlayZone4()
    {
        staticTargetingPlayZone4 = false;
    }
    public void TargetPlayZone4()
    {
        staticTargetingPlayZone4 = true;
    }
    public void StartPlay()
    {
        staticTargeting = true;
    }
    public void StopPlay()
    {
        staticTargeting = false;

    }
    public void OneCardPlay()
    {
        onlyThisCardPlay = true;
    }
    public void OneCardPlayStop()
    {
        onlyThisCardPlay = false;
    }
    
}

















//Instead of canAttack and cantAttack(?) use IsInDropzone or something similar