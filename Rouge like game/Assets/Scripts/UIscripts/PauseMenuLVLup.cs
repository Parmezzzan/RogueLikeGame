using System.Collections.Generic;
using UnityEngine;

public class PauseMenuLVLup : MonoBehaviour
{
    [SerializeField]
    PlayerLvLUpdater updater;
    [SerializeField]
    float timeBeforePause = 0.02f;
    [SerializeField]
    GameObject UICardPrefab;
    [SerializeField]
    List<CardLevel> cardList;

    private int lvlsUpCounter = 0;
    private bool inProcess = false;

    int? skill = null;
    List<GameObject> cardDeck;
    private void Start()
    {
        cardDeck = new List<GameObject>();
    }
    public void onLVLup()
    {
        lvlsUpCounter++;

        if(!inProcess)
            LvLUP();
    }
    private void LvLUP()
    {
        inProcess = true;
        cardList = updater.GetLevelUpCards();
        if (cardList.Count != 0)
        {
            Invoke("Pause", timeBeforePause);
            cardDeck.Clear();
            foreach (var card in cardList)
            {
                var newUicard = Instantiate(UICardPrefab, Vector3.zero, Quaternion.identity, transform);
                newUicard.GetComponent<CardLoaderManager>().LoadInfo(gameObject, card);
                cardDeck.Add(newUicard);
            }
        }
    }
    private void Pause()
    {
        Time.timeScale = 0.0f;
    }
    public void ChoiceCard(CardLevel chosenCard)
    {
        updater.ChosenCard(chosenCard);
        foreach (var card  in cardDeck)
        {
            Destroy(card);
        }
        Time.timeScale = 1.0f;

        inProcess = false;
        lvlsUpCounter--;

        if (lvlsUpCounter > 0 && !inProcess)
        {
            LvLUP();
            lvlsUpCounter--;
        }
    }
}
