using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelUtility : MonoBehaviour
{

    #region Public Variables
    #endregion

    #region Private Variables
    #endregion

    #region Public Methods
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    #endregion

    #region Private Methods
    #endregion

}