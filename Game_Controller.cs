using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Controller : MonoBehaviour
{

    #region public Variables
    public int Score { get { return score; } }//properties just for score of player in this game
    public HUD_TOP_LEFT_manager hud_top_left_manager;
    public GameObject hud_top_right_manager;
    public GameObject PauseButton;
    public CoinRepository coinRepo = new CoinRepository();
    public ScoreRepository scoreRepo;
    public ShipRepository shipRepos;
    public JoyStick joystick;
    public Text txtBullet;
    public int dangerBulletCount;
    public Sprite blueSprite;
    public Sprite redSprite;
    public Image COUNT_OF_BULLET;
    public WinGameOverManager winGameOverPanel;
    public LevelRepository levelRepo;
    //public AudioClip startClipWin;
    //public AudioClip startClipGameOver;
    public GameLog gameLog;
    #endregion

    #region private Variables
    private int score;//the score of player
    private int bullet = 100;//bullets of all characters
    private int coins = 0; //coins of player that collected
    private int destroyedItems = 0; //number of destroyed items in this level
    private ShipStruct ship;
    private int bulletOutOfBounds = 0;
    ShipController shipController;
    //private int template = 0;
    //private AudioSource audioSourceWin;
    //private AudioSource audioSourceGameOver;
    #endregion

    #region public Methods
    public int GetHealthPercent()
    {
        return shipController.GetHealthPercent();
    }
    public void Win()
    {

        if (winGameOverPanel.gameObject.activeInHierarchy == false)
        {
            //winGameOverPanel.Init(true);
            levelRepo.OpenNextLevel();
            joystick.Dettach();
            hud_top_right_manager.SetActive(false);
            hud_top_left_manager.DeActive();
            PauseButton.SetActive(false);
            winGameOverPanel.gameObject.SetActive(true);
            winGameOverPanel.Init(true, score, GetBulletsOnTargetPercent(shipController.GetBulletFired()), destroyedItems, coins);
            ShowCoins(coins);
            //audioSourceWin.PlayOneShot(startClipWin);
        }

    }
    public void GameOver(int numOfBullets)
    {
        //Debug.Log("Game Over...!!!");
        joystick.Dettach();
        //hud_top_right_manager.DeActive();
        hud_top_right_manager.SetActive(false);
        hud_top_left_manager.DeActive();
        PauseButton.SetActive(false);
        winGameOverPanel.gameObject.SetActive(true);
        winGameOverPanel.Init(false, score, GetBulletsOnTargetPercent(numOfBullets) , destroyedItems , coins);
        ShowCoins(coins);
        //audioSourceGameOver.PlayOneShot(startClipGameOver);
    }
    public int ShowCoins(int coins)
    {
        return coins;
    }
    public void GameObjectDeactivator(GameObject obj)
    {
        if (obj.tag == "Bullet_Character")
        {
            bulletOutOfBounds += 1;
            gameLog.AddBulletOutOfBounds();
        }

        Destroy(obj.gameObject);
    }
    public void AddScore(int s)
    {
        if (s > 0)
        {
            score += s;
            hud_top_left_manager.SetScoreText(score);

        }
    }
    public bool HasBullet()
    {
        if (bullet > 0) { return true; } else { return false; }
    }
    public void PopBullet()
    {
        bullet = bullet - 1;
        //hud_top_right_manager.SetBullet(bullet);
        txtBullet.text = bullet.ToString();
        if (bullet >= dangerBulletCount)
        {
            COUNT_OF_BULLET.sprite = blueSprite;
        }
        else
        {
            COUNT_OF_BULLET.sprite = redSprite;
        }
    }
    public void AddCoin()
    {
        coins = coins + 1;
        gameLog.AddCoins();
        //return coins;
    }
    public void AddDestroyedItems(string tag)
    {
        if (tag == "Asteroid")
        {
            gameLog.AddAsteroidDestroyed();
        }else if (tag == "Ship_enemy")
        {
            gameLog.AddUnitEnemyShipDestroyed();
        }
        destroyedItems += 1;
    }
    //public int checksCoins(int coins)
    //{
        //template = coins;
        //return coinRepo.Get(template);
        //return template;
    //}
    //public int ReturnCoins()
    //{
        //template += coins;
        //return template;
    //}
    #endregion

    #region private Methods
    private void Start()
    {
        //Invoke("Test" , 3);
        ship = shipRepos.GetCurrentShip();
        GameObject shipObject = ((GameObject) Instantiate(ship.ship , Vector3.zero , Quaternion.identity));
        shipController = shipObject.GetComponent<ShipController>();
        shipController.Init(ship.speed , ship.fireRate , ship.health);
        joystick.Attach(shipController);
        score = 0;
        bullet = 100;//i mean the bullet is belongs to the const package
        coins = 0;
        destroyedItems = 0;
        hud_top_left_manager.SetScoreText(score);
        //hud_top_right_manager.SetBullet(bullet);
        txtBullet.text = bullet.ToString();
        if (bullet >= dangerBulletCount)
        {
            COUNT_OF_BULLET.sprite = blueSprite;
        }
        else
        {
            COUNT_OF_BULLET.sprite = redSprite;
        }
        //Debug.Log(coinRepo.Get().ToString());
        //Debug.Log("Last score is: "+scoreRepo.GetLastScore()+"\tAnd HighScore is"+scoreRepo.GetHighScore());
        winGameOverPanel.gameObject.SetActive(false);
    }
    private void Test()
    {
        //Instantiate(shipRepos.GetCurrentShip(), Vector3.zero, Quaternion.identity);
    }
    private void Update()
    {
        //Debug.Log(coins.ToString());
        //if(coins >= 7 && destroyedItems >= 5)
        //{
            //if ((winGameOverPanel.gameObject.activeInHierarchy) == false){ Win(); }
            //checksCoins(coins);
        //}
        //Debug.Log(checksCoins(coins));
        //function_Coins = checksCoins(coins);
    }
    private void OnApplicationQuit()
    {
        //Debug.Log("GOOD BYE");
        coins += PlayerPrefs.GetInt("coin");
        PlayerPrefs.SetInt("coin",coins);
        coinRepo.Push(coins);
        scoreRepo.Push(score);
    }
    private int GetBulletsOnTargetPercent(int total)
    {
        float onTarget = total - bulletOutOfBounds;
        float template = (onTarget / total) * 100;
        int intTemplate = (int)template;
        return Mathf.Clamp(intTemplate , 0 , 100);
    }
    #endregion
}