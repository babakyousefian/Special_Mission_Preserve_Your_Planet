using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonLevelController : MonoBehaviour
{

    #region Public Variables
    public Image lockImage;
    public Text txtLevelNumber;
    #endregion

    #region Private Variables
    private bool isOpen;
    private int number;
    #endregion

    #region Public Methods
    public void Init(int num , bool Open)
    {
        isOpen = Open;
        if (isOpen == true) 
        {
            txtLevelNumber.gameObject.SetActive(true);
            lockImage.gameObject.SetActive(false);
            txtLevelNumber.text = (num + 1).ToString();
            number = num;
        }
        else
        {
            txtLevelNumber.gameObject.SetActive(false);
            lockImage.gameObject.SetActive(true);
        }
    }
    public void Click()
    {
        Debug.Log("CLICK");
        if (isOpen)
        {
            //open level
            string sceneName = "Level " + number;
            SceneManager.LoadScene(sceneName);

        }
    }
    #endregion

    #region Private Methods
    #endregion

}