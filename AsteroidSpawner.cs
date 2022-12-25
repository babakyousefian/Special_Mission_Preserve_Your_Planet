using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AsteroidSpawner : MonoBehaviour
{

    #region public Variables
    public GameObject[] asteriodsPrefab;
    public Vector2 timeToSpawn;
    public Vector2 xAxisLimitToSpawn;
    #endregion

    #region private Variables
    #endregion

    #region public Methods
    #endregion

    #region private Methods
    private void Start()
    {
        StartCoroutine(Spawn());
        //Invoke("Spawn" , Random.Range(timeToSpawn.x , timeToSpawn.y));
    }
    //private void Spawn()
    //{
    //    Instantiate(asteriodPrefab , transform.position , Quaternion.identity);
    //    Invoke("Spawn", Random.Range(timeToSpawn.x, timeToSpawn.y));
    //}
    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(timeToSpawn.x , timeToSpawn.y));
        Vector3 pos = transform.position;
        pos.x = Random.Range(xAxisLimitToSpawn.x , xAxisLimitToSpawn.y);
        int random = Random.Range(0 , asteriodsPrefab.Length);
        Instantiate(asteriodsPrefab[random] , pos , Quaternion.identity);
        StartCoroutine(Spawn());
    }
    #endregion

}
