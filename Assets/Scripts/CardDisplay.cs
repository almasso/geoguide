using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI capitalText;
    public TextMeshProUGUI languajeText;
    public TextMeshProUGUI currencyText;
    public TextMeshProUGUI climateText;
    public TextMeshProUGUI infoText;
    public Image mapPosImage;
    public Image flagImage;
    public Image memoryImage;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = card.name;
        capitalText.text = card.capital;
        languajeText.text = card.languaje;
        currencyText.text = card.currency;
        climateText.text = card.climate;
        infoText.text = card.info;
        mapPosImage.sprite = card.mapPos;
        flagImage.sprite = card.flag;
        memoryImage.sprite = card.memory;
    }

}
