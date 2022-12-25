using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_TOP_LEFT_manager : MonoBehaviour
{

    #region public Variables
    public Text Text_Health_Percent;
    public Text Text_Score;
    public Sprite blueSprite;
    public Sprite redSprite;
    public Image mainImage;
    public Game_Controller gameController;
    #endregion

    #region private Variables
    #endregion

    #region public Methods
    public void SetScoreText(int score)
    {
        Text_Score.text = score.ToString();
    }
    public void DeActive()
    {
        gameObject.SetActive(false);
    }
    #endregion

    #region private Methods
    private void Start()
    {
        //Text_Health_Percent.text = Random.Range(0, 100).ToString();
        //Text_Score.text = Random.Range(100, 3000).ToString();
    }
    private void Update()
    {
        //Text_Score.text = gameController.Score.ToString();
    }
    private void LateUpdate()
    {
        int healthPercent = gameController.GetHealthPercent();
        Text_Health_Percent.text = healthPercent.ToString();
        if(healthPercent > 60)
        {
            mainImage.sprite = blueSprite;
        }
        else
        {
            mainImage.sprite = redSprite;
        }
    }
    #endregion
}
