using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallexScrolling : MonoBehaviour
{

    #region public Variables
    public Vector2 Speed;
    #endregion

    #region private Variables
    private Renderer MyRender;
    #endregion

    #region public Methods
    #endregion

    #region private Methods
    private void Awake()
    {
        MyRender= GetComponent<Renderer>();
    }
    private void Update()
    {
        MyRender.material.mainTextureOffset = (Time.time * Speed);
    }
    #endregion

}