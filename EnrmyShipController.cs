using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnrmyShipController : MonoBehaviour
{

    #region public Variables
    public float Vspeed;//vertical speed
    public float Hspeed;//horizontal speed
    public GameObject BulletPrefab;
    public Vector2 TimeToFire;
    public GameObject Gun;
    public int power;
    public GameObject firePrefab;
    #endregion

    #region private Variables
    private int direction = 0;// 1 --> right , -1 --> left , 0 --> don't move
    private Game_Controller gameController;
    private int initPower;
    #endregion

    #region public Methods
    #endregion

    #region private Methods
    private void Start()
    {
        initPower = power;
        gameController = GameObject.FindObjectOfType<Game_Controller>();
        InvokeRepeating("ChangeDirection", 1, 0.5f);
        InvokeRepeating("Fire", TimeToFire.x, TimeToFire.y);
    }
    private void Update()
    {
        Vector3 move = Vector3.down;
        move.x = direction * Hspeed;
        move.y = move.y * Vspeed;
        transform.position += (move * Time.deltaTime);
        CheckSpaceshipOutOfBounds();
    }
    private void CheckSpaceshipOutOfBounds()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -7.71f, 7.71f);
        transform.position = pos;
    }
    private void ChangeDirection()
    {
        direction = Random.Range(-1, 2);//-1 , 0 , 1
    }
    private void Fire()
    {
        Instantiate(BulletPrefab, Gun.transform.position, Quaternion.identity);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        power = power - collision.gameObject.GetComponent<BulletController>().power;
        CheckPower();
    }
    private void CheckPower()
    {
        gameController.AddScore(initPower);
        gameController.AddDestroyedItems(gameObject.tag);
        Instantiate(firePrefab , transform.position , Quaternion.identity);
        Destroy(gameObject);
    }
    #endregion
}