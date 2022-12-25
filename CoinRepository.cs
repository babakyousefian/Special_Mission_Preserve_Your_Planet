using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRepository : MonoBehaviour
{

    #region public Veriables
    public string RepositoryNAME { get { return repositoryName; } }
    #endregion

    #region private Variables
    private int coins;
    #endregion

    #region const Variables
    private const string repositoryName = "CoinRepository";
    #endregion

    #region public Methods
    public bool Pop(int count)
    {
        if (Has(count))
        {
            coins -= count;
            SaveRepo(coins);
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Push(int count)
    {
        if(count>0)
        {
            coins += count;
            SaveRepo(coins);
        }
    }
    public void Save()
    {
        SaveRepo(coins);
    }
    public int Get()
    {
        SaveRepo(coins);
        return coins;
    }
    #endregion

    #region private Methods
    private bool Has(int count)
    {
        if (coins >= count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void Start()
    {
        if(PlayerPrefs.HasKey(repositoryName))
        {
            coins = Retrieve();
        }
        else
        {
            coins = 0;
        }
    }
    private void SaveRepo(int coins)
    {
        PlayerPrefs.SetInt(RepositoryNAME, coins);
    }
    private int Retrieve()
    {
        return PlayerPrefs.GetInt(repositoryName);
    }
    private void Update()
    {
        //Debug.Log(Get());
    }
    #endregion

}