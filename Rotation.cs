using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    #region public Variables
    public Vector3 Speed;
    #endregion

    #region private Variables
    #endregion

    #region public Methods
    #endregion

    #region private Methods
    private void Update()
    {
        transform.Rotate(Speed * Time.deltaTime);
    }
    #endregion

}
