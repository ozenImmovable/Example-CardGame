using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    void Awake ()
    {


        //Add cardtype denotations to end of list


        cardList.Add(new Card(0, "None", "None", 0, 0, "None", Resources.Load <Sprite>("image1"), 0, 0));
        cardList.Add(new Card(1, "ally", "Ally 1", 1, 3, "This card should be destroyed on play", Resources.Load<Sprite>("elf"), 0, 0));
        cardList.Add(new Card(2, "ally", "Ally 2", 1, 7, "This card should be destroyed on play", Resources.Load<Sprite>("elf"), 0, 0));
        cardList.Add(new Card(3, "ally", "Ally 3", 2, 3, "This card should be destroyed on play", Resources.Load<Sprite>("elf"), 0, 0));
        cardList.Add(new Card(4, "ally", "Ally 4", 3, 20, "This card should be destroyed on play", Resources.Load<Sprite>("elf"), 0, 0));
        cardList.Add(new Card(5, "ally", "Ally 5", 2, 1, "This card should be destroyed on play", Resources.Load<Sprite>("elf"), 0, 0));
        cardList.Add(new Card(6, "material", "Material 6", 1, 2345, "This card is temporarily destroyed on play", Resources.Load<Sprite>("material"), 0, 0));
        cardList.Add(new Card(7, "material", "Material 7", 2, 345, "This card is temporarily destroyed on play", Resources.Load<Sprite>("material"), 0, 0));
        cardList.Add(new Card(8, "material", "Material 8", 1, 0, "This card is temporarily destroyed on play", Resources.Load<Sprite>("material"), 0, 0));
        cardList.Add(new Card(9, "material", "Material 9", 1, 435, "This card is temporarily destroyed on play", Resources.Load<Sprite>("material"), 0, 0));
        cardList.Add(new Card(10, "material", "Material 10", 1, 0, "This card is temporarily destroyed on play", Resources.Load<Sprite>("material"), 0, 0));
        cardList.Add(new Card(11, "spell", "Spell 11", 1, 0, "This card goes directly to discard on play", Resources.Load<Sprite>("spell"), 0, 0));
        cardList.Add(new Card(12, "spell", "Spell 12", 1, 0, "This card goes directly to discard on play", Resources.Load<Sprite>("spell"), 0, 0));
        cardList.Add(new Card(13, "spell", "Spell 13", 2, 0, "This card goes directly to discard on play", Resources.Load<Sprite>("spell"), 0, 0));
        cardList.Add(new Card(14, "spell", "Spell 14", 1, 0, "This card goes directly to discard on play", Resources.Load<Sprite>("spell"), 0, 0));
        cardList.Add(new Card(15, "spell", "Spell 15", 1, 0, "This card goes directly to discard on play", Resources.Load<Sprite>("spell"), 0, 0));
    }
}
