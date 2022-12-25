using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameLog : MonoBehaviour
{

    #region Public Variables
    public int bulletShots;
    public int bulletOutOfBounds;
    public int bulletOnTarget;
    public int asteroidDestroyed;
    public int asteroidCrossed;
    public int unitEnemyShipDestroyed;
    public int unitEnemyShipCrossed;
    public int motherEnemyShipDestroyed;
    public int motherEnemyShipCrossed;
    public int coins;
    #endregion

    #region Private Variables
    #endregion

    #region Public Methods
    public void AddBullet()
    {
        bulletShots++;
    }
    public void AddBulletOnTarget()
    {
        bulletOnTarget++;
    }
    public void AddBulletOutOfBounds()
    {
        bulletOutOfBounds++;
    }
    public void AddAsteroidDestroyed()
    {
        asteroidDestroyed++;
    }
    public void AddAsteroidCrossed()
    {
        asteroidCrossed++;
    }
    public void AddUnitEnemyShipDestroyed()
    {
        unitEnemyShipDestroyed++;
    }
    public void AddUnitEnemyShipCrossed()
    {
        unitEnemyShipCrossed++;
    }
    public void AddMotherEnemyShipDestroyed()
    {
        motherEnemyShipDestroyed++;
    }
    public void AddMotherEnemyShipCrossed()
    {
        motherEnemyShipCrossed++;
    }
    public void AddCoins()
    {
        coins++;
    }
    #endregion

    #region Private Methods
    #endregion

}