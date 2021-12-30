using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    void Awake ()
    {


        //Add cardtype denotations to end of list


        cardList.Add(new Card(0, "None", 0, 0, "None", Resources.Load <Sprite>("image1"), 0, 0, "none"));
        cardList.Add(new Card(1, "Ally Card 1", 1, 0, "This card should be destroyed on play", Resources.Load<Sprite>("elf"), 0, 0, "ally"));
        cardList.Add(new Card(2, "Ally Card 2", 1, 0, "This card should be destroyed on play", Resources.Load<Sprite>("elf"), 0, 0, "ally"));
        cardList.Add(new Card(3, "Ally Card 3", 1, 0, "This card should be destroyed on play", Resources.Load<Sprite>("elf"), 0, 0, "ally"));
        cardList.Add(new Card(4, "Ally Card 4", 1, 0, "This card should be destroyed on play", Resources.Load<Sprite>("elf"), 0, 0, "ally"));
        cardList.Add(new Card(5, "Ally Card 5", 1, 0, "This card should be destroyed on play", Resources.Load<Sprite>("elf"), 0, 0, "ally"));
        cardList.Add(new Card(6, "Material Card 6", 1, 0, "This card is temporarily destroyed on play", Resources.Load<Sprite>("dwarf"), 0, 0, "material"));
        cardList.Add(new Card(7, "Material Card 7", 1, 0, "This card is temporarily destroyed on play", Resources.Load<Sprite>("dwarf"), 0, 0, "material"));
        cardList.Add(new Card(8, "Material Card 8", 1, 0, "This card is temporarily destroyed on play", Resources.Load<Sprite>("dwarf"), 0, 0, "material"));
        cardList.Add(new Card(9, "Material Card 9", 1, 0, "This card is temporarily destroyed on play", Resources.Load<Sprite>("dwarf"), 0, 0, "material"));
        cardList.Add(new Card(10, "Material Card 10", 1, 0, "This card is temporarily destroyed on play", Resources.Load<Sprite>("dwarf"), 0, 0, "material"));
        cardList.Add(new Card(11, "Spell Card 11", 1, 0, "This card goes directly to discard on play", Resources.Load<Sprite>("human"), 0, 0, "spell"));
        cardList.Add(new Card(12, "Spell Card 12", 1, 0, "This card goes directly to discard on play", Resources.Load<Sprite>("human"), 0, 0, "spell"));
        cardList.Add(new Card(13, "Spell Card 13", 1, 0, "This card goes directly to discard on play", Resources.Load<Sprite>("human"), 0, 0, "spell"));
        cardList.Add(new Card(14, "Spell Card 14", 1, 0, "This card goes directly to discard on play", Resources.Load<Sprite>("human"), 0, 0, "spell"));
        cardList.Add(new Card(15, "Spell Card 15", 1, 0, "This card goes directly to discard on play", Resources.Load<Sprite>("human"), 0, 0, "spell"));
    }
}
