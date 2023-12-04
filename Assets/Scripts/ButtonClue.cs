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
        boton = gameObject.GetComponent<Button>();
        image = gameObject.GetComponent<Image>();
        boton.interactable = false;
         text = _myText.GetComponent<Clue>();
        bckgrndText = _myBackgorungText.GetComponent<Clue>();
    }
    public void EnableButton()
    {
        boton.interactable = true;
        ShowClue();
        _enabled = true;
    }

    public void ShowClue()
    {
        text.MoveClue(-1);
        bckgrndText.MoveClue(-1);
    }

    public void HideClue()
    {
        text.MoveClue(1);
        bckgrndText.MoveClue(1);
    }
  
    public void OnPressed()
    {
        if (_enabled) HideClue();
        else ShowClue();
        _enabled = !_enabled;
        image.transform.Rotate(new Vector3(0, 0, 180));
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
