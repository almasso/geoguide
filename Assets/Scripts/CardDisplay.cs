using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : Save_Load
{
    //public Card card;
    public int index = 0;
    private bool isActive;
    private Image cardImage;
    private TextMeshProUGUI nameText;
    private TextMeshProUGUI capitalText;
    private TextMeshProUGUI languajeText;
    private TextMeshProUGUI currencyText;
    private TextMeshProUGUI climateText;
    private TextMeshProUGUI infoText;
    private Image mapPosImage;
    private Image flagImage;
    private Image memoryImage;
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        isActive = myCardList.card[index].isActive;
        cardImage = gameObject.GetComponent<Image>();
        nameText = gameObject.transform.GetChild(0).gameObject.transform.GetComponent<TextMeshProUGUI>();
        capitalText = gameObject.transform.GetChild(1).gameObject.transform.GetComponent<TextMeshProUGUI>();
        languajeText = gameObject.transform.GetChild(2).gameObject.transform.GetComponent<TextMeshProUGUI>();
        currencyText = gameObject.transform.GetChild(3).gameObject.transform.GetComponent<TextMeshProUGUI>();
        climateText = gameObject.transform.GetChild(4).gameObject.transform.GetComponent<TextMeshProUGUI>();
        infoText = gameObject.transform.GetChild(5).gameObject.transform.GetComponent<TextMeshProUGUI>();
        mapPosImage = gameObject.transform.GetChild(6).gameObject.transform.GetComponent<Image>();
        flagImage = gameObject.transform.GetChild(7).gameObject.transform.GetComponent<Image>();
        memoryImage = gameObject.transform.GetChild(8).gameObject.transform.GetComponent<Image>();
        button = gameObject.transform.GetChild(9).gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate () { CardManager.Instance.ExpandCard(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject); });


        if (myCardList.card[index].isActive == true)
        {
            //Debug.Log(cartaActivada);
            cardImage.sprite = cartaActivada;
            nameText.text = myCardList.card[index].name;
            capitalText.text = myCardList.card[index].capital;
            languajeText.text = myCardList.card[index].languaje;
            currencyText.text = myCardList.card[index].currency;
            climateText.text = myCardList.card[index].climate;
            infoText.text = myCardList.card[index].info;
            mapPosImage.sprite = Resources.Load<Sprite>(myCardList.card[index].mapPos);
            flagImage.sprite = Resources.Load<Sprite>(myCardList.card[index].flag);
            memoryImage.sprite = Resources.Load<Sprite>(myCardList.card[index].memory);
        }
        else
        {
            cardImage.sprite = cartaDesactivada;
            mapPosImage.GetComponent<Image>().enabled = false;
            flagImage.enabled = false;
            memoryImage.enabled = false;
        }
    }

}
