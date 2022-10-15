using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardLoaderManager : MonoBehaviour
{
    [SerializeField]
    Image logoImage;
    [SerializeField]
    TextMeshProUGUI title;
    [SerializeField]
    TextMeshProUGUI info;

    private CardLevel card;
    private GameObject sender;
    public void LoadInfo(GameObject senderObj, CardLevel inCard)
    {
        logoImage.sprite = inCard.Icon;
        title.text = inCard.Name;
        info.text = inCard.Info;
        card = inCard;
        sender = senderObj;
    }
    public void OnChoise()
    {
        sender.GetComponent<PauseMenuLVLup>().ChoiceCard(card);
    }
}
