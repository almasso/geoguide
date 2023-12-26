using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkieController : MonoBehaviour
{
    private Transform _myTransform;
    private float mostrado, escondido;
    private bool mostrar = false;
    private bool posFinal = false;
    [SerializeField] private float _showSpeed;
    void Start()
    {
        _myTransform = this.transform;
        mostrado = _myTransform.localPosition.y;
        escondido = mostrado - 500;
        _myTransform.localPosition = new Vector3(_myTransform.localPosition.x, escondido, _myTransform.localPosition.z);
    }

    public bool isCompletelyShown() { return posFinal; }
    public bool isDoingShowingAnim() { return mostrar && !posFinal; }
    public bool isDoingHidingAnim() { return !mostrar && !posFinal; }
    public bool hasBeenCalled() { return mostrar; }

    public bool isAtInitialPos() { return (_myTransform.localPosition.y - escondido) < 2f; }

    public void showWalkie() { mostrar = true; SoundManager.Instance.PlaySFX(SoundManager.Instance.walkieTalkie); }
    public void hideWalkie() { mostrar = false; }

    private void FixedUpdate()
    {
        if (mostrar && (mostrado - _myTransform.localPosition.y) >= 2f)
        {
            _myTransform.localPosition = Vector3.Lerp(_myTransform.localPosition, new Vector3(_myTransform.localPosition.x, mostrado, _myTransform.localPosition.z), _showSpeed * Time.fixedDeltaTime);
        }
        else if (mostrar) posFinal = true;
        else if (!mostrar && (_myTransform.localPosition.y - escondido) >= 2f)
        {
            posFinal = false;
            _myTransform.localPosition = Vector3.Lerp(_myTransform.localPosition, new Vector3(_myTransform.localPosition.x, escondido, _myTransform.localPosition.z), _showSpeed * Time.fixedDeltaTime);
        }
    }
}
