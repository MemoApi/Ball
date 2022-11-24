using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class LaserPool : MonoBehaviour
{


    public Queue<GameObject> LaserObjectPool;
    public GameObject laserPrefab;


    private void Awake()
    {
        SetLaserPool();

    }


    private void SetLaserPool()
    {
            LaserObjectPool = new Queue<GameObject>();

        for (int i = 0; i < 10; i++)
        {

            GameObject laser = Instantiate(laserPrefab,transform);
            laser.SetActive(false);
            LaserObjectPool.Enqueue(laser);
        }
    }

    public GameObject GetLaserObject()
    {
        GameObject laser = LaserObjectPool.Dequeue();
        laser.SetActive(true);
        LaserObjectPool.Enqueue(laser);

        return laser;

    }


}
