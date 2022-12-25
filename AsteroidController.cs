using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{

    #region public Variables
    public float speed;
    public float rotationSpeed;
    public int health;
    public GameObject ExplosionPrefab;
    public Sprite[] HealthSprite;
    public GameObject coinSpawner;
    #endregion

    #region private Variables
    private const string ANIMATION_NAME = "Health";
    private Animator animator;
    private SpriteRenderer SpriteRender;
    private Game_Controller game_Controller;
    private int InitHealth;
    #endregion

    #region public Methods
    #endregion

    #region private Methods
    private void Awake()
    {
        InitHealth = health;
        animator= GetComponent<Animator>();
        SpriteRender = GetComponent<SpriteRenderer>();
        game_Controller = GameObject.FindObjectOfType<Game_Controller>();
    }
    private void Update()
    {
        transform.position += (Vector3.down * speed * Time.deltaTime);
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        animator.SetInteger(ANIMATION_NAME , health);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet_Character")
        {
            health -= collision.gameObject.GetComponent<BulletController>().power;
            CheckHealth();
        }
        else if (collision.gameObject.tag == "Player")
        {
            Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
            CheckHealth();
            Destroy(gameObject);
            //health -= collision.gameObject.GetComponent<ShipController>().InitHealth;
            //CheckHealth();
        }
        //if (collision.gameObject.tag == "Player")
        //{
        //health = health - collision.gameObject.GetComponent<BulletController>().power;
        //Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        //Destroy(gameObject);
        //CheckHealth();
        //}
        //CheckHealth();
    }
    private void CheckHealth()
    {
        if (health <= 0)
        {
            game_Controller.AddScore(InitHealth);
            game_Controller.AddDestroyedItems(gameObject.tag);
            int random = Random.Range(1,8);
            if (random % 2 == 0)
            {
                Instantiate(coinSpawner , transform.position , Quaternion.identity);
            }
            Instantiate(ExplosionPrefab , transform.position , Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            DoAnimationOrChangeSprite();
        }
    }
    private void DoAnimationOrChangeSprite()
    {
        if(animator != null)
        {
            animator.SetInteger(ANIMATION_NAME , health);
        }
        else
        {
            ChangeSprite();
        }
    }
    private void ChangeSprite()
    {
        SpriteRender.sprite = HealthSprite[health - 1];
    }
    #endregion
}