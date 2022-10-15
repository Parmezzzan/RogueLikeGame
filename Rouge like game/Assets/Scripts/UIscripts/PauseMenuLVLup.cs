using System.Collections.Generic;
using UnityEngine;

public class PauseMenuLVLup : MonoBehaviour
{
    [SerializeField]
    PlayerLvLUpdater updater;
    [SerializeField]
    GameObject UICardPrefab;
    [SerializeField]
    List<CardLevel> cardList;

    int? skill = null;
    List<GameObject> cardDeck;
    private void Start()
    {
        cardDeck = new List<GameObject>();
    }
    public void onLVLup()
    {
        Invoke("Pause", 0.5f);
        cardList = updater.GetLevelUpCards();

        cardDeck.Clear();
        foreach (var card in cardList)
        {
            var newUicard = Instantiate(UICardPrefab, Vector3.zero , Quaternion.identity, transform);
            newUicard.GetComponent<CardLoaderManager>().LoadInfo(gameObject ,card);
            cardDeck.Add(newUicard);
        }
    }
    private void Pause()
    {
        Time.timeScale = 0.0f;
    }
    public void SkkillChoise(int N)
    {
        skill = N;
    }
    public void ExitMenu()
    {
        if(skill != null)
        {
            Time.timeScale = 1.0f;
            skill = null;
            gameObject.SetActive(false);
        }
    }
    public void ChoiceCard(CardLevel chosenCard)
    {
        updater.ChosenCard(chosenCard);
        foreach (var card  in cardDeck)
        {
            Destroy(card);
        }
        Time.timeScale = 1.0f;
    }
}
