using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpaceShipShopController : MonoBehaviour
{

    #region Public Variables
    public Text txtCoins;
    public Text txtModel;
    public GameObject pnlSpeed;
    public GameObject pnlHealth;
    public Text txtGunType;
    public GameObject pnlFireRate;
    public GameObject pnlGunCount;
    public GameObject pnlBulletPower;
    public Text txtprice;
    public Image shipSprite;
    public GameObject btnSelect;
    public GameObject btnBuy;
    public GameObject btnAddCoins;
    public LockController lockController;
    [Header("Repositories")]
    public CoinRepository coinRepo;
    public ShipRepository shipRepo;
    #endregion

    #region Private Variables
    private ShipStruct currentShip;
    private Game_Controller gc = new Game_Controller();
    //private int coins=0;
    private int i = 0;
    private int x = 12414;
    #endregion

    #region Public Methods
    public void NextShip()
    {
        i = i + 1;
        if (i >= shipRepo.ShipsCount)
        {
            i = 0;
        }
        currentShip = shipRepo.GetShipByIndex(i);
        UpdateInformation(currentShip);
    }
    public void PrevShip()
    {
        i = i - 1;
        if (i < 0)
        {
            i = shipRepo.ShipsCount - 1;
        }
        currentShip = shipRepo.GetShipByIndex(i);
        UpdateInformation(currentShip);
    }
    public void SelectShip()
    {
        shipRepo.SetCurrentShip((int)currentShip.key);
    }
    public void BuyShip()
    {
        if (coinRepo.Pop(currentShip.price))
        {
            shipRepo.ActiveNewShip((int)currentShip.key);
            UpdateButtons(false , currentShip.price , coinRepo.Get());
            UpdateCoin();
        }
    }
    public void AddCoin()
    {
        coinRepo.Push(200);
        UpdateCoin();
        UpdateButtons(currentShip.isLocked , currentShip.price , coinRepo.Get());
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    #endregion

    #region Private Methods
    private void Start()
    {
        UpdateCoin();
        i = 0;
        currentShip = shipRepo.GetShipByIndex(i);
        UpdateInformation(currentShip);
    }
    private void UpdateCoin()
    {
        //txtCoins.text = coinRepo.Get().ToString();
        //int template1 = gc.checksCoins(coins);
        txtCoins.text = ((coinRepo.Get())-x).ToString();
        currentShip = shipRepo.GetCurrentShip();
        UpdateInformation(currentShip);
    }
    private void UpdateInformation(ShipStruct ship)
    {
        txtModel.text = ship.model;
        shipSprite.sprite = ship.sprite;
        SetGunType(ship.bulletType);
        SetPrice(ship.price);
        InitializeBars(pnlHealth , ship.health);
        InitializeBars(pnlSpeed , ship.speed);
        InitializeBars(pnlFireRate , ((int)(ship.fireRate * 10)));
        InitializeBars(pnlGunCount , ship.guns);
        InitializeBars(pnlBulletPower , ship.bulletPower);
        UpdateButtons(ship.isLocked , ship.price , (coinRepo.Get())-x);
        lockController.SetStatus(ship.isLocked);
    }
    private void UpdateButtons(bool isLocked , int price , int coins)
    {
        btnAddCoins.gameObject.SetActive(false);
        btnBuy.gameObject.SetActive(false);
        btnSelect.gameObject.SetActive(false);
        if(isLocked == true && coins >= price)
        {
            btnBuy.gameObject.SetActive(true);
        }else if (isLocked == true && coins < price)
        {
            btnAddCoins.gameObject.SetActive(true);
        }else if (isLocked == false)
        {
            btnSelect.gameObject.SetActive(true);
        }

    }
    private void SetGunType(BulletType type)
    {
        switch (type)
        {
            case BulletType.Bomb:
                txtGunType.text = "bomb";
                break;
            case BulletType.Leaser:
                txtGunType.text = "leaser";
                break;
            case BulletType.Rocket:
                txtGunType.text = "rocket";
                break;
        }
    }
    private void SetPrice(int price)
    {
        if (price == 0)
        {
            txtprice.text = "Free";
        }
        else
        {
            txtprice.text = price.ToString();
        }
    }
    private void InitializeBars(GameObject panel , int count)
    {
        int childCount = panel.transform.childCount;
        for (int i=0; i<childCount; i++)
        {
            RadioButtonManager child = panel.transform.GetChild(i).GetComponent<RadioButtonManager>();
            if(i < count)
            {
                child.Enable();
            }
            else
            {
                child.Disable();
            }
        }
    }
    #endregion

}