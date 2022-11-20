using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    public static event Action CoinCollided;
    public static event Action ObstacleCollided;
    public static event Action GameFinished;
    


    //Singleton
    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }




    public void CoinCollision() => CoinCollided?.Invoke();
    public void ObstacleCollision() => ObstacleCollided?.Invoke();
    public void GameFinish() => GameFinished?.Invoke();
   



}
