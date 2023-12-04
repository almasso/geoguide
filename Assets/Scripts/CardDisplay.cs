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

    // Start is called before the first frame update
    void Start()
    {
        if (myCardList.card[index].isActive == true)
        {
            Debug.Log(cartaActivada);
            gameObject.GetComponent<Image>().sprite = cartaActivada;
            gameObject.transform.GetChild(0).gameObject.transform.GetComponent<TextMeshProUGUI>().text = myCardList.card[index].name;
            gameObject.transform.GetChild(1).gameObject.transform.GetComponent<TextMeshProUGUI>().text = myCardList.card[index].capital;
            gameObject.transform.GetChild(2).gameObject.transform.GetComponent<TextMeshProUGUI>().text = myCardList.card[index].languaje;
            gameObject.transform.GetChild(3).gameObject.transform.GetComponent<TextMeshProUGUI>().text = myCardList.card[index].currency;
            gameObject.transform.GetChild(4).gameObject.transform.GetComponent<TextMeshProUGUI>().text = myCardList.card[index].climate;
            gameObject.transform.GetChild(5).gameObject.transform.GetComponent<TextMeshProUGUI>().text = myCardList.card[index].info;
            gameObject.transform.GetChild(6).gameObject.transform.GetComponent<Image>().sprite = AssetDatabase.LoadAssetAtPath<Sprite>(myCardList.card[index].mapPos);
            gameObject.transform.GetChild(7).gameObject.transform.GetComponent<Image>().sprite = AssetDatabase.LoadAssetAtPath<Sprite>(myCardList.card[index].flag);
            gameObject.transform.GetChild(8).gameObject.transform.GetComponent<Image>().sprite = AssetDatabase.LoadAssetAtPath<Sprite>(myCardList.card[index].memory);

            //cardImage.sprite = cartaActivada;
            //nameText.text = myCardList.card[index].name;
            //capitalText.text = myCardList.card[index].capital;
            //languajeText.text = myCardList.card[index].languaje;
            //currencyText.text = myCardList.card[index].currency;
            //climateText.text = myCardList.card[index].climate;
            //infoText.text = myCardList.card[index].info;
            //mapPosImage.sprite = AssetDatabase.LoadAssetAtPath<Sprite>(myCardList.card[index].mapPos);
            //flagImage.sprite = AssetDatabase.LoadAssetAtPath<Sprite>(myCardList.card[index].flag);
            //memoryImage.sprite = AssetDatabase.LoadAssetAtPath<Sprite>(myCardList.card[index].memory);
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = cartaDesactivada;
            gameObject.transform.GetChild(6).gameObject.transform.GetComponent<Image>().enabled = false;
            gameObject.transform.GetChild(7).gameObject.transform.GetComponent<Image>().enabled = false;
            gameObject.transform.GetChild(8).gameObject.transform.GetComponent<Image>().enabled = false;
        }
    }

}
