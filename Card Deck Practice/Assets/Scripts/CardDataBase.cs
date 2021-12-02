using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    void Awake ()
    {
        cardList.Add(new Card(0, "None", 0, 0, "None", Resources.Load <Sprite>("image1")/*, 0, 0*/));
        cardList.Add(new Card(1, "Elf", 2, 2000, "This Elf increases your max mana by 1", Resources.Load<Sprite>("elf")/*, 0, 1*/));
        cardList.Add(new Card(2, "Dwarf", 3, 3000, "This Dwarf card draws you 2 cards", Resources.Load<Sprite>("dwarf")/*, 2, 0)*/));
        cardList.Add(new Card(3, "Human", 5, 5000, "This Human card draws you a card and increases your max mana by 1", Resources.Load<Sprite>("human")/*, 1, 1*/));
        cardList.Add(new Card(4, "Demon", 1, 1000, "This Demon card draws you two cards", Resources.Load<Sprite>("demon")/*, 2, 0*/));
    }
}
