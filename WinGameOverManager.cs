using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinGameOverManager : MonoBehaviour
{

    #region Public Variables
    public Text txtWinMessage;
    public Text txtScore;
    public Text txtAccuracy;
    public Text txtDestroyed;
    public Text txtCoin;
    public GameObject btnReplay;
    public GameObject btnNextLevel;
    public AudioClip startClip;
    public AudioClip startClipGameOver;
    public AudioClip btnReplayClip;
    public AudioClip btnMainMenuClip;
    #endregion

    #region Private Variables
    [SerializeField]
    private AudioSource audioSource;
    #endregion

    #region Private Const Variables
    private string winMessage = "Congratulations! you win";
    private string gameOverMessage = "you lose...!!! please try again";
    #endregion

    #region Public Methods
    public void Init(bool isWin , int score , int accuracy , int destroyed , int coins)
    {
        SetWinMessage(isWin);
        SetButtons(isWin);
        txtScore.text = score.ToString();
        txtAccuracy.text = accuracy.ToString()+" %";
        txtDestroyed.text = destroyed.ToString();
        txtCoin.text = coins.ToString();
        if(isWin == true)
        {
            audioSource.PlayOneShot(startClip);
        }else if(isWin == false)
        {
            audioSource.PlayOneShot(startClipGameOver);
        }
    }
    public void ReplayGame()
    {
        audioSource.PlayOneShot(btnReplayClip);
        Invoke("ReplayGameAfterSound" , btnReplayClip.length);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Application.LoadLevel(0);
        //Application.LoadLevel("Level 01");
    }
    public void MainMenu()
    {
        audioSource.PlayOneShot(btnMainMenuClip);
        Invoke("GoToMainMenuAfterSound" , btnMainMenuClip.length);
        //SceneManager.LoadScene("MainMenu");
    }
    #endregion

    #region Private Methods
    private void GoToMainMenuAfterSound()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private void ReplayGameAfterSound()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void SetWinMessage(bool isWin)
    {
        if(isWin == true)
        {
            txtWinMessage.text = winMessage;
        }
        else
        {
            txtWinMessage.text = gameOverMessage;
        }
    }
    private void SetButtons(bool isWin)
    {
        if (isWin == true)
        {
            btnReplay.SetActive(false);
            btnNextLevel.SetActive(true);
        }
        else
        {
            btnReplay.SetActive(true);
            btnNextLevel.SetActive(false);
        }
    }
    #endregion

}