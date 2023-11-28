using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardManager : MonoBehaviour
{
    #region references
    static private CardManager _instance;
    /// <summary>
    /// Public accesor for GameManager instance.
    /// </summary>
    static public CardManager Instance
    {
        get
        {
            return _instance;
        }
    }

    GameObject myCanvasObject = null;
    GameObject myPanel = null;
    GameObject myCard = null;
    bool cardExpanded = false;

    [SerializeField]
    private GameObject _UIManager;
    private UI_Manager _myUIManager;
#endregion


#region methods
    private void Awake()
    {
        _instance = this;
    }

    public void ExpandCard(GameObject button)
    {
        // Canvas
        myCanvasObject = new GameObject("CardCanvas");
        myCanvasObject.AddComponent<Canvas>();
        myCanvasObject.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        myCanvasObject.AddComponent<CanvasScaler>();
        myCanvasObject.AddComponent<GraphicRaycaster>();

        // Panel
        myPanel = new GameObject("panel");
        myPanel.AddComponent<CanvasRenderer>();
        myPanel.AddComponent<BoxCollider2D>();
        Image i = myPanel.AddComponent<Image>();
        Color color; color.r = 0; color.g = 0; color.b = 0; color.a = 0.3f;
        i.color = color;
        myPanel.transform.SetParent(myCanvasObject.transform, false);
        myPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(myCanvasObject.GetComponent<RectTransform>().sizeDelta.x, myCanvasObject.GetComponent<RectTransform>().sizeDelta.y);

        // Carta
        myCard = Instantiate(button.transform.parent.gameObject);
        Destroy(myCard.transform.GetChild(9).gameObject);
        myCard.transform.parent = myCanvasObject.transform;

        myCard.transform.localScale += new Vector3(1.3f, 1.3f, 1.3f);
        myCard.transform.position = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);

        cardExpanded = true;
    }

    void destroyCard()
    {
        if (myCard != null) Destroy(myCard);
        if (myPanel != null) Destroy(myPanel);
        if (myCanvasObject != null) Destroy(myCanvasObject);

        cardExpanded = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        _myUIManager = _UIManager.GetComponent<UI_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cardExpanded && Input.GetMouseButtonDown(0))
        {
            destroyCard();
        }
    }

    #endregion
}
