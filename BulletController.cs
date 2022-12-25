using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletDirection
{
    UP,
    DOWN
}
public class BulletController : MonoBehaviour
{

    #region public Variables
    public float speed;
    public BulletDirection direction;
    public GameObject ExplosionPrefab;
    public int power;
    public Sprite[] sprites;
    #endregion

    #region private Variables
    private Vector3 move = Vector3.down;
    [SerializeField]
    private SpriteRenderer SpriteRender;
    #endregion

    #region public Methods
    #endregion

    #region private Methods
    private void Start()
    {
        SpriteRender.sprite = sprites[Random.Range(0 , sprites.Length - 1)];
        if (direction == BulletDirection.DOWN)
        {
            move = Vector3.down;
        }
        else
        {
            move = Vector3.up;
        }
    }
    private void Update()
    {
        //transform.position += Vector3.up * speed * Time.deltaTime;
        transform.Translate(move * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        Instantiate(ExplosionPrefab, col.contacts[0].point, Quaternion.identity);
        //Destroy(col.gameObject);
        Destroy(gameObject);
    }
    #endregion

}