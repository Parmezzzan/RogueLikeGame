using System.Collections.Generic;
using UnityEngine;

public class PlayerLvLUpdater : MonoBehaviour
{
    [SerializeField]
    private int maxCardOnUI = 4;
    [SerializeField]
    private List<LevelUpdateBranch> playerLvLbranches = new List<LevelUpdateBranch>();
    [SerializeField]
    private PlayerBuffManager playerBuffManager;

    private List<int> currentLevels;
    private void Start()
    {
        currentLevels = new List<int>();
        for (int i = 0; i < playerLvLbranches.Count; i++)
        {
            currentLevels.Add(0);
        } 
    }
    public List<CardLevel> GetLevelUpCards()
    {
        var cardList = new List<CardLevel>();

        if (playerLvLbranches.Count <= maxCardOnUI)
        {
            print("chosen cards..");
            print(playerLvLbranches.Count);
            for (int i = 0; i < playerLvLbranches.Count; i++)
            {
                print("branch!");
                if (currentLevels[i] < playerLvLbranches[i].cardsLevel.Count)
                {
                    cardList.Add(playerLvLbranches[i].cardsLevel[currentLevels[i]]);
                    print("add a card");
                    currentLevels[i]++;
                }
                else
                {
                    print("dont add card");
                }
            }
        }
        else
        {
            var chosenBranches = new List<int>();
            for (int i = 0; i < maxCardOnUI; i++)
            {
                int indexz = Random.Range(0, 4);
                while(chosenBranches.Contains(indexz))    indexz = Random.Range(0, 4);
                chosenBranches.Add(indexz);

                if (currentLevels[i] != playerLvLbranches[indexz].cardsLevel.Count)
                {
                    cardList.Add(playerLvLbranches[indexz].cardsLevel[currentLevels[i]]);
                    currentLevels[i]++;
                }
            }
        }

        return cardList;
    }
    public void ChosenCard(CardLevel chosenCard)
    {
        for (int i = 0; i < playerLvLbranches.Count; i++)
        {
            if (playerLvLbranches[i].cardsLevel.Contains(chosenCard)) 
            { 
                currentLevels[i]++;
                RealiseCard(chosenCard);
                break;
            } 
        }
    }
    private void RealiseCard(CardLevel cardForRealise)
    {
        foreach (var buff in cardForRealise.CardBuffs)
        {
            playerBuffManager.AddBuff(buff);
        }
    }
}