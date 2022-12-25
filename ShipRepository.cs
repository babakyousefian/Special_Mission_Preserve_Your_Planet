using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public enum ShipEnums
{
    Green1,
    Green2,
    Green3,
    Red1,
    Red2,
    Red3,
    Blue1,
    Blue2,
    Blue3
}
public enum BulletType
{
    Leaser,
    Rocket,
    Bomb
}
[System.Serializable]
public struct ShipStruct
{
    public ShipEnums key; //types of ship
    public GameObject ship; //ship prefab
    [Range(1,10)]
    public int speed; //the speed of each spaceship
    [Range(1, 10)]
    public int health; //health of ship
    [Range(1, 3)]
    public int guns; //count of guns
    [Range(1,3)]
    public int bulletPower; //power of bullets
    public string model; //the name of ship
    public BulletType bulletType; // type of bullets
    public int price; // the price of each spaceship
    public bool isLocked; // i mean the player at this game can not buy spaceship yet
    [Range(0.0f,1f)]
    public float fireRate; // the time of each bullets fireing between each gap in the space
    public Sprite sprite; // the sprite of each spaceship
}
public class ShipRepository : MonoBehaviour
{

    #region Public Variables
    public ShipStruct[] ships;
    public int ShipsCount { get { return ships.Length; } }
    #endregion

    #region Private Variables
    #endregion

    #region Const Variables
    private const string currentShipRepo = "currentshiprepo";
    private const string shipsRepos = "shipsRepo";
    #endregion

    #region Public Methods
    public ShipStruct GetCurrentShip()
    {
        int index = PlayerPrefs.GetInt(currentShipRepo);
        //ships[index].isLocked = true; // or maybe is equal with false
        ships[index].isLocked = IsShipActive(index);
        return ships[index];
    }
    public ShipStruct GetShipByIndex(int i)
    {
        ships[i].isLocked = !IsShipActive(i);
        return ships[i];
    }
    public void SetCurrentShip(int i)
    {
        PlayerPrefs.SetInt(currentShipRepo, i);
    }
    public void ActiveNewShip(int i)
    {
        string s = RetrieveShips();
        s = s + i.ToString();
        SaveShips(s);
    }
    #endregion

    #region Private Methods
    private void Awake()
    {
        //int random = Random.Range(0,9);
        //PlayerPrefs.SetInt(currentShipRepo , (int)ShipEnums.Red1);
        //PlayerPrefs.SetInt(currentShipRepo , random);
        Init();
    }
    private void Init()
    {
        if (PlayerPrefs.HasKey(shipsRepos) == false)
        {
            SetCurrentShip(0);
            string s = "0";
            SaveShips(s);
        }
    }
    private void SaveShips(string s)
    {
        PlayerPrefs.SetString(shipsRepos, s);
    }
    private string RetrieveShips()
    {
        return PlayerPrefs.GetString(shipsRepos);
    }
    private bool IsShipActive(int i)
    {
        string s = PlayerPrefs.GetString(shipsRepos);
        if (s.Contains(i.ToString()))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion
}