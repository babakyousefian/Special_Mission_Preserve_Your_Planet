using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    #region public Variables
    //Transform mytransform;
    public GameObject bulletPrefab;
    public GameObject[] Guns;
    public int Health { get { return _health; } }
    public int InitHealth { get { return initHealth; } }
    public Animator FlameAnimator;
    #endregion

    #region private Variables
    private float FireRate = 0.3f;
    private float speed;
    [SerializeField]
    private int _health;
    private float lastShot = 0;
    private const string FLAME_ANIMATION = "Speed";
    private float h;
    private float v;
    private Game_Controller gameController = new Game_Controller(); // refrence to the game controller
    private int numOfBullets = 0;
    private int initHealth;
    #endregion

    #region public Methods
    public int GetBulletFired()
    {
        return numOfBullets;
    }
    public void Init(float _speed , float _fireRate , int _h)
    {
        speed = _speed;
        FireRate = _fireRate;
        _health = _h;
        initHealth = _health;
    }
    public void FireBullet()
    {
        Fire();
    }
    public void MoveUp()
    {
        v = 1;
        CheckSpaceShipOutOfBounds();
    }
    public void MoveDown()
    {
        v = -1;
        CheckSpaceShipOutOfBounds();
    }
    public void MoveLeft()
    {
        h = -1;
        CheckSpaceShipOutOfBounds();
    }
    public void MoveRight()
    {
        h = 1;
        CheckSpaceShipOutOfBounds();
    }
    public void StopMoving()
    {
        v = 0;
        h = 0;
        CheckSpaceShipOutOfBounds();
    }
    public int GetHealthPercent()
    {
        if (initHealth == _health){return 100;}
        float reminderHealth = initHealth - _health;
        float template = (reminderHealth / initHealth) * 100;
        return (int)template;
    }
    #endregion

    #region private Methods
    private void Start()
    {
        numOfBullets = 0;
        //mytransform = GetComponent<Transform>();
        gameController = GameObject.FindObjectOfType<Game_Controller>();
    }

    private void Update()
    {
        //h = Input.GetAxis("Horizontal");
        //v = Input.GetAxis("Vertical");
        CheckKeyboardPushInput();
        Vector3 move = new Vector3(speed * h * Time.deltaTime, speed * v * Time.deltaTime, 0);
        transform.position += move;
        FlameAnimator.SetFloat(FLAME_ANIMATION , move.sqrMagnitude);
        CheckSpaceShipOutOfBounds();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("Fire Bullet!");
            Fire();
        }
    }
    private void CheckKeyboardPushInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            MoveUp();
        }else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            MoveDown();
        }
        CheckKeyboardPullInput();
    }
    private void CheckKeyboardPullInput()
    {
        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A) 
            || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D)
              || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W)
                || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            StopMoving();
        }
    }
    private void Fire()
    {
        if ((Time.time > FireRate+lastShot) && (gameController.HasBullet()))
        {
            for (int i = 0; i < Guns.Length; i++)
            {
                numOfBullets += 1;
                Instantiate(bulletPrefab, Guns[i].transform.position, Quaternion.identity);
                gameController.PopBullet();
            }
            lastShot = Time.time;
        }
    }
    private void CheckSpaceShipOutOfBounds()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -8.12f, 8.12f),
            Mathf.Clamp(transform.position.y, -4.21f, 3.63f),
            transform.position.z
            );
        //if (transform.position.x < -11.28f)
        //{
        //    Vector3 pos = transform.position;
        //    pos.x = -11.28f;
        //    transform.position = pos;
        //}
        //if (transform.position.x > 11.28f)
        //{
        //    Vector3 pos = transform.position;
        //    pos.x = 11.28f;
        //    transform.position = pos;
        //}
        //if (transform.position.y > 3.63f)
        //{
        //    Vector3 pos = transform.position;
        //    pos.y = 3.63f;
        //    transform.position = pos;

        //}
        //if (transform.position.y < -4.21f)
        //{
        //    Vector3 pos = transform.position;
        //    pos.y = -4.21f;
        //    transform.position = pos;
        //}
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Asteroid")
        {
            _health -= col.gameObject.GetComponent<AsteroidController>().health;
            CheckHealth();
        }
        else if (col.gameObject.tag == "Bullet_enemy")
        {
            _health -= col.gameObject.GetComponent<BulletController>().power;
            CheckHealth();
        }
        else if (col.gameObject.tag == "Ship_enemy")
        {
            _health -= col.gameObject.GetComponent<EnrmyShipController>().power;
            CheckHealth();
        }
        //else if (col.gameObject.tag == "Coin")
        //{
        //    gameController.AddCoin();
        //    Destroy(col.gameObject);
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin")
        {
            //Destroy(collision.gameObject);
            collision.gameObject.GetComponent<Coin_Controller>().DestroyIt();
            gameController.AddCoin();
            //gameController.checksCoins(gameController.AddCoin());
        }
    }
    private void CheckHealth()
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
            gameController.GameOver(numOfBullets);
        }
    }
    #endregion
}