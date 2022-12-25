using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRepository : MonoBehaviour
{

    #region Public Variables
    public string RepositoryName { get { return lastScoreRepository; } }
    #endregion

    #region Private Variables
    #endregion

    #region Const Variables
    private const string lastScoreRepository = "lastscoreRepository";
    private const string highScoreRepository = "highscoreRepository";
    #endregion

    #region Public Mathods
    public void Push(int s)
    {
        Save(lastScoreRepository , s);
        int h = GetHighScore();
        if (s > h)
        {
            Save(highScoreRepository , s);
        }
    }
    public int GetLastScore()
    {
        return Retrieve(lastScoreRepository);
    }
    public int GetHighScore()
    {
        return Retrieve(highScoreRepository);
    }
    #endregion

    #region Private Methods
    private int Retrieve(string key)
    {
        return PlayerPrefs.GetInt(key);
    }
    private void Save(string key , int val)
    {
        PlayerPrefs.SetInt(key,val);
    }
    #endregion

}