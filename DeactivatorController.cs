using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivatorController : MonoBehaviour
{

    #region Public Variables
    #endregion

    #region Private Variables
    private Game_Controller gameController;
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void Start()
    {
        gameController = GameObject.FindObjectOfType<Game_Controller>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.GameObjectDeactivator(collision.gameObject);
    }
    #endregion

}