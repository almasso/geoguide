using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroller : MonoBehaviour
{
    #region Parameters
    /// <summary>
    /// Speed used to move the texture
    /// </summary>
    public float _scrollSpeed;
    #endregion

    #region References
    /// <summary>
    /// Reference to own Sprite Renderer
    /// </summary>
    private SpriteRenderer _mySpriteRenderer;
    /// <summary>
    /// Reference to own Material
    /// </summary>
    private Material _myMaterial;
    #endregion

    #region methods
    /// <summary>
    /// Disables the component, so the texture movement stops
    /// </summary>
    public void Stop()
    {
        this.enabled = false;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _mySpriteRenderer = GetComponent<SpriteRenderer>();
        _myMaterial = _mySpriteRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        _myMaterial.mainTextureOffset += new Vector2(Time.deltaTime * _scrollSpeed, 0);
    }
}
