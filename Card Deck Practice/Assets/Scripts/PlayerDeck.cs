using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerDeck : MonoBehaviour
{

    public List<Card> deck = new List<Card>();
    public List<Card> container = new List<Card>();
    public static List<Card> staticDeck = new List<Card>();

    public int x;
    public static int deckSize;

    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;

    public GameObject CardToHand;
    public GameObject Cardback;

    public GameObject[] Clones;

    public GameObject Hand;

    //Shuffle text code initialization
    public Text NotificationText;  
    private float timeToAppear = 1f;
    private float timeWhenDisappear;



    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        deckSize = 40;

        for(int i = 0; i<40/*deckSize*/; i++)
        {
            x = Random.Range(1, 15);
            deck[i] = CardDataBase.cardList[x];
        }

        StartCoroutine(StartGame());
    }

    // Update is called once per frame
    void Update()
    {
        
        staticDeck = deck;


        if (deckSize < 30)
        {
            cardInDeck1.SetActive(false);
        }
        if (deckSize < 20)
        {
            cardInDeck2.SetActive(false);
        }
        if (deckSize < 2)
        {
            cardInDeck3.SetActive(false);
        }
        if (deckSize < 1)
        {
            cardInDeck4.SetActive(false);
        }
        
        //shuffle text update code starts here
        if(NotificationText.enabled && (Time.time >= timeWhenDisappear))
        {
            NotificationText.enabled = false;
        }

        //calls coroutine to draw cards
        if(ThisCard.drawX > 0)
        {
            StartCoroutine(Draw(ThisCard.drawX));
            ThisCard.drawX = 0;
        }

        if(TurnSystem.startTurn == true)
        {
            StartCoroutine(Draw(1));
            TurnSystem.startTurn = false;

        }
    }

    
    IEnumerator Example()
    {
        yield return new WaitForSeconds(1);
        Clones = GameObject.FindGameObjectsWithTag("Clone");

        foreach(GameObject Clone in Clones)
        {
            Destroy(Clone);
        }
    }

    IEnumerator StartGame()
    {
        for(int i=0; i < 4; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
    }
    
    public void Shuffle()
    {
        for(int i =0; i < deckSize; i++)
        {
            container[0] = deck[i];
            int randomIndex = Random.Range(i, deckSize);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container[0];
        }

        //Instantiate(Cardback, transform.position, transform.rotation);

        StartCoroutine(Example());
    }

    //shuffle text code class starts here
    public void EnableShuffleText()
    {
        NotificationText.enabled = true;
        timeWhenDisappear = Time.time + timeToAppear;
    }

    IEnumerator Draw(int x)
    {
        for (int i = 0; i < x; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
    }
    
}
