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
            print(playerLvLbranches.Count);
            for (int i = 0; i < playerLvLbranches.Count; i++)
            {
                if (currentLevels[i] < playerLvLbranches[i].cardsLevel.Count)
                {
                    cardList.Add(playerLvLbranches[i].cardsLevel[currentLevels[i]]);
                }
            }
        }
        else
        {
            List<int> branchNoMax = new List<int>();
            for (int j = 0; j < playerLvLbranches.Count; j++)
                if (currentLevels[j] < playerLvLbranches[j].cardsLevel.Count)
                    branchNoMax.Add(j);

            int maxCard = branchNoMax.Count >= maxCardOnUI ? maxCardOnUI : branchNoMax.Count;

            int chosenCardNum = 0;
            while(chosenCardNum < maxCard)
            {
                int index = Random.Range(0, playerLvLbranches.Count);
                if (branchNoMax.Contains(index))
                {
                    cardList.Add(playerLvLbranches[index].cardsLevel[currentLevels[index]]);
                    chosenCardNum++;
                    branchNoMax.Remove(index);
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