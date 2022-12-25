using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Controller : MonoBehaviour
{

    #region public Variables
    public float Speed;
    //public AudioClip[] clips;
    public AudioClip clip;
    public AudioSource audioSource;
    #endregion

    #region private Variables
    private Vector2 direction;
    #endregion

    #region public Methods
    public void DestroyIt()
    {
        StartCoroutine(DestroyAfterSound());
    }
    #endregion

    #region private Methods
    private IEnumerator DestroyAfterSound()
    {
        yield return new WaitForSeconds(clip.length - 0.2f);
        Destroy(gameObject);
    }
    private void Start()
    {
        //clip = clips[Random.Range(0 , clips.Length)];
        audioSource.PlayOneShot(clip);
        direction = Vector2.up;
        direction.x = Random.Range(-4f , 4f);
        Invoke("GoDown" , 0.4f);
    }
    private void Update()
    {
        transform.Translate(direction * Speed * Time.deltaTime);
    }
    private void GoDown()
    {
        direction.y *= -1;
        direction.x = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //clip = clips[Random.Range(0, clips.Length)];
            audioSource.PlayOneShot(clip);
        }
    }
    #endregion

}