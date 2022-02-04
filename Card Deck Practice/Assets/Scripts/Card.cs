using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Card
{
    //These are varibales for each of the possible/common values among cards
    public int id;
    public string cardName;
    public int cost;
    public int power;
    public string cardDescription;

    public int drawXcards;
    public int addXmaxMana;
    public Sprite thisImage;

    //public bool ally;
    //public bool material;
    //public bool spell;

    public string cardType;

    public Card()
    {
    
    }

    public Card(int Id, string Cardtype, string CardName, int Cost, int Power, string CardDescription, Sprite ThisImage, int DrawXcards, int AddXmaxMana )
    {
        id = Id;
        cardName = CardName;
        cost = Cost;
        power = Power;
        cardDescription = CardDescription;

        thisImage = ThisImage;

        drawXcards = DrawXcards;
        addXmaxMana = AddXmaxMana;

        cardType = Cardtype;


    }
}
