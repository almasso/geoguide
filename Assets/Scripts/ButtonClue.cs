using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClue : MonoBehaviour
{
    private Clue text;
    private Clue bckgrndText;
   [SerializeField]
    public GameObject _myText;
    [SerializeField]
    public GameObject _myBackgorungText;
    public bool _enabled = false;
    private Button boton;
    private Image image;
    private void Start()
    {
        boton = gameObject.GetComponent<Button>();
        image = gameObject.GetComponent<Image>();
        EnableButton(true);
        text = _myText.GetComponent<Clue>();
        bckgrndText = _myBackgorungText.GetComponent<Clue>();
    }
    public void EnableButton(bool active)
    {
        boton.interactable = active;
    }

    public void ShowClue()
    {
        text.MoveClue(1);
        bckgrndText.MoveClue(1);
    }

    public void HideClue()
    {
        text.MoveClue(-1);
        bckgrndText.MoveClue(-1);
    }
  
    public void OnPressed()
    {
        if (_enabled) HideClue();
        else ShowClue();
        _enabled = !_enabled;
        image.transform.Rotate(new Vector3(0, 0, 180));
    }
}
