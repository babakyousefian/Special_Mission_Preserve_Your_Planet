using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level11 : MonoBehaviour
{

    #region Public Variables
    #endregion

    #region Private Variables
    [SerializeField]
    private GameLog gameLog;
    [SerializeField]
    private Game_Controller gameController;
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void Update()
    {
        if (gameLog.coins >= 38 && gameLog.asteroidDestroyed >= 40)
        {
            gameController.Win();
        }
    }
    #endregion

}
