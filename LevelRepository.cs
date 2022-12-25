using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRepository : MonoBehaviour
{

    #region Public Variables
    public int levelCount = 15;
    #endregion

    #region Private Variables
    #endregion

    #region Const Variables
    private string REPOSITORY_NAME = "levelRepository";
    #endregion

    #region Public Methods
    public bool IsLocked(int i)
    {
        string[] s = RetrieveLevelsFromRepoToArray();
        if (s[i] == "1")
        {
            return true;
        }
        else if (s[i] != "1")
        {
            return false;
        }
        else if (s[i] == "2")
        {
            return true;
        }
        else if (s[i] != "2")
        {
            return false;
        }
        else if (s[i] == "3")
        {
            return true;
        }
        else if (s[i] != "3")
        {
            return false;
        }
        else if (s[i] == "4")
        {
            return true;
        }
        else if (s[i] != "4")
        {
            return false;
        }
        else if (s[i] == "5")
        {
            return true;
        }
        else if (s[i] != "5")
        {
            return false;
        }
        else if (s[i] == "6")
        {
            return true;
        }
        else if (s[i] != "6")
        {
            return false;
        }
        else if (s[i] == "7")
        {
            return true;
        }
        else if (s[i] != "7")
        {
            return false;
        }
        else if (s[i] == "8")
        {
            return true;
        }
        else if (s[i] != "8")
        {
            return false;
        }
        else if (s[i] == "9")
        {
            return true;
        }
        else if (s[i] != "9")
        {
            return false;
        }
        else if (s[i] == "10")
        {
            return true;
        }
        else if (s[i] != "10")
        {
            return false;
        }
        else if (s[i] == "11")
        {
            return true;
        }
        else if (s[i] != "11")
        {
            return false;
        }
        else if (s[i] == "12")
        {
            return true;
        }
        else if (s[i] != "12")
        {
            return false;
        }
        else if (s[i] == "13")
        {
            return true;
        }
        else if (s[i] != "13")
        {
            return false;
        }
        else if (s[i] == "14")
        {
            return true;
        }
        else if (s[i] != "14")
        {
            return false;
        }
        else if (s[i] == "15")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void OpenLevel(int i)
    {
        string[] s = RetrieveLevelsFromRepoToArray();
        s[i] = "1";
        string newS = ConvertToString(s);
        SaveRepo(newS);
    }
    public void OpenNextLevel()
    {
        int index = 0;
        string[] s = RetrieveLevelsFromRepoToArray();
        for (int i=0; i<s.Length; i++)
        {
            if (s[i]== "0")
            {
                index = i;
                break;
            }
        }
        OpenLevel(index+1);
    }
    public bool[] RetrieveAllLevels()
    {
        bool[] levelArray = new bool[levelCount];
        string[] levels = RetrieveLevelsFromRepoToArray();
        for (int i=0; i<levelCount; i++)
        {
            if (levels[i] == "1")
            {
                levelArray[i] = true;
            }
            else if (levels[i] != "1")
            {
                levelArray[i] = false;
            }
            else if (levels[i] == "2")
            {
                levelArray[i] = true;
            }
            else if (levels[i] != "2")
            {
                levelArray[i] = false;
            }
            else if (levels[i] == "3")
            {
                levelArray[i] = true;
            }
            else if (levels[i] != "3")
            {
                levelArray[i] = false;
            }
            //if (levels[i] == "4")
            //{
            //    levelArray[i] = true;
            //}
            //else
            //{
            //    levelArray[i] = false;
            //}
            //if (levels[i] == "5")
            //{
            //    levelArray[i] = true;
            //}
            //else
            //{
            //    levelArray[i] = false;
            //}
            //if (levels[i] == "6")
            //{
            //    levelArray[i] = true;
            //}
            //else
            //{
            //    levelArray[i] = false;
            //}
            //if (levels[i] == "7")
            //{
            //    levelArray[i] = true;
            //}
            //else
            //{
            //    levelArray[i] = false;
            //}
            //if (levels[i] == "8")
            //{
            //    levelArray[i] = true;
            //}
            //else
            //{
            //    levelArray[i] = false;
            //}
            //if (levels[i] == "9")
            //{
            //    levelArray[i] = true;
            //}
            //else
            //{
            //    levelArray[i] = false;
            //}
            //if (levels[i] == "10")
            //{
            //    levelArray[i] = true;
            //}
            //else
            //{
            //    levelArray[i] = false;
            //}
            //if (levels[i] == "11")
            //{
            //    levelArray[i] = true;
            //}
            //else
            //{
            //    levelArray[i] = false;
            //}
            //if (levels[i] == "12")
            //{
            //    levelArray[i] = true;
            //}
            //else
            //{
            //    levelArray[i] = false;
            //}
            //if (levels[i] == "13")
            //{
            //    levelArray[i] = true;
            //}
            //else
            //{
            //    levelArray[i] = false;
            //}
            //if (levels[i] == "14")
            //{
            //    levelArray[i] = true;
            //}
            //else
            //{
            //    levelArray[i] = false;
            //}
            //if (levels[i] == "15")
            //{
            //    levelArray[i] = true;
            //}
            //else
            //{
            //    levelArray[i] = false;
            //}
        }
        return levelArray;
    }
    #endregion

    #region Private Methods
    private string[] RetrieveLevelsFromRepoToArray()
    {
        string levels = PlayerPrefs.GetString(REPOSITORY_NAME);
        return levels.Split('-');
    }
    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        //if(PlayerPrefs.HasKey(REPOSITORY_NAME) == false)
        //{
            string s = "1-1-0-0-0-0-0-0-0-0-0-0-0-0-0";
            SaveRepo(s);
        //}
    }
    private string ConvertToString(string[] s)
    {
        string newS = "";
        for (int i=0; i<s.Length; i++)
        {
            newS = newS + s[i];
            if(i != s.Length - 1)
            {
                newS = newS + "-";
            }
        }
        return newS;
    }
    private void SaveRepo(string s)
    {
        PlayerPrefs.SetString(REPOSITORY_NAME, s);
    }
    #endregion
}