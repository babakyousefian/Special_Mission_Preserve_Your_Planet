using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuController : MonoBehaviour
{

    #region Public Variables
    #endregion

    #region Private Variables
    #endregion

    #region Public Methods
    public void StartGame()
    {
        SceneManager.LoadScene("Level 0");
    }
    public void SpaceShipShop()
    {
        SceneManager.LoadScene("SpaceShipShop");
    }
    public void OpenLevelManager()
    {
        SceneManager.LoadScene("LevelManager");
    }
    #endregion

    #region Private Methods
    #endregion

}