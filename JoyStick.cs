using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStick : MonoBehaviour
{

    #region Public Variables
    public GameObject joystickButton;
    public GameObject FireButton;
    #endregion

    #region Private Variables
    private ShipController ship;
    #endregion

    #region Public Methods
    public void Fire()
    {
        ship.FireBullet();
    }
    public void MoveLeft()
    {
        ship.MoveLeft();
    }
    public void MoveRight()
    {
        ship.MoveRight();
    }
    public void MoveDown()
    {
        ship.MoveDown();
    }
    public void MoveUp() 
    { 
        ship.MoveUp();
    }
    public void StopMoving()
    {
        ship.StopMoving();
    }
    public void Attach(ShipController s)
    {
        ship = s;
        GUIActivator(true);
    }
    public void Dettach()
    {
        ship = null;
        GUIActivator(false);
    }
    #endregion

    #region Private Methods
    private void GUIActivator(bool active)
    {
        joystickButton.gameObject.SetActive(active);
        FireButton.SetActive(active);
    }
    private void Start()
    {
        if (ship == null)
        {
            GUIActivator(false);
        }
    }
    //private void LateUpdate()
    //{
    //if(ship == null)
    //{
    //joystickButton.gameObject.SetActive(false);
    //FireButton.SetActive(false);
    //ship = GameObject.FindObjectOfType<ShipController>();
    //}
    //else
    //{
    //joystickButton.gameObject.SetActive(true);
    //FireButton.SetActive(true);
    //}
    //}
    #endregion
}