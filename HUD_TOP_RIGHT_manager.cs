using Packages.Rider.Editor.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_TOP_RIGHT_manager : MonoBehaviour
{

    #region public Variables
    public int dangerBulletCount;
    public Sprite blueSprite;
    public Sprite redSprite;
    public Image COUNT_OF_BULLET;
    public Text txtBullet;
    #endregion

    #region private Variables
    private Text Remains_Bullet;
    #endregion

    #region public Methods
    public void SetBullet(int bullet)
    {
        txtBullet.text = bullet.ToString();
        if(bullet >= dangerBulletCount)
        {
            COUNT_OF_BULLET.sprite = blueSprite;
        }
        else
        {
            COUNT_OF_BULLET.sprite = redSprite; 
        }
    }
    public void DeActive()
    {
        gameObject.SetActive(false);

    }
    #endregion

    #region private Methods
    private void Start()
    {
        txtBullet = GameObject.FindGameObjectWithTag("Remains_Bullet").GetComponent<Text>();
        //Remains_Bullet.text = 100+ "";
    }
    #endregion

}
