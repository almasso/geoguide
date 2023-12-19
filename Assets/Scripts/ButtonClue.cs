using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClue : MonoBehaviour
{
    [SerializeField]
    private float timeToActivate;
    private float _elapsedTime;
    private Clue text;
    private Clue bckgrndText;
    [SerializeField]
    public GameObject _myText;
    [SerializeField]
    public GameObject _myBackgorungText;
    public bool _enabled = false;
    public bool active = false;
    private Button boton;
    private Image image;
    private void Start()
    {
        boton = gameObject.transform.GetChild(2).gameObject.GetComponent<Button>();
        image = gameObject.transform.GetChild(2).gameObject.GetComponent<Image>();
        boton.interactable = false;
        text = gameObject.transform.GetChild(1).gameObject.GetComponent<Clue>();
        bckgrndText = gameObject.transform.GetChild(0).gameObject.GetComponent<Clue>();
    }
    public bool isActive()
    {
        return active; 
    }
    public void EnableButton()
    {
        boton.interactable = true;
        ShowClue();
        _enabled = true;
    }
    public void DesableButton()
    {
        boton.interactable = false;
        HideClue();
         _enabled = false;
    }
    public void ShowClue()
    {
        text.MoveClue(-1);
        bckgrndText.MoveClue(-1);
        image.transform.Rotate(new Vector3(0, 0, 180));
    }

    public void HideClue()
    {
        text.MoveClue(1);
        bckgrndText.MoveClue(1);
        image.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
  
    public void OnPressed()
    {
        if (_enabled) HideClue();
        else ShowClue();
        _enabled = !_enabled;
        
    }

    public void hasChangedClient()
    {
        text.HideClue();
        bckgrndText.HideClue();
        boton.interactable = false;
        image.transform.rotation = Quaternion.Euler(0, 0, 0);
        _enabled = false;
        _elapsedTime = 0;
        active = false;
    }

    public void setMaximumElapsedTime()
    {
        _elapsedTime = timeToActivate;
    }

    void Update()
    {
        if (!active)
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= timeToActivate)
            {
                active = true;
                EnableButton();
            }
        }
    }
}
