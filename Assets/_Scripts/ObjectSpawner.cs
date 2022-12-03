using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // xpos limit = +-6


    // playerdan 60birim uzakta obje oluþturulacak 

    


    public GameObject[] obstacle;
    public GameObject laserLauncher;
    public GameObject coinWave;

    public Queue<GameObject> obstaclePool;
    public Queue<GameObject> laserLauncherPool;
    public Queue<GameObject> coinWavePool;
     
    private Transform player;
    private float launcherXPosLimit = 6;

    private void Awake()
    {
        obstaclePool = new Queue<GameObject>();
        laserLauncherPool = new Queue<GameObject>();
        coinWavePool = new Queue<GameObject>();





        for (int i = 0; i < 4; i++)
        {
            GameObject obj = Instantiate(coinWave);
            obj.SetActive(false);
            coinWavePool.Enqueue(obj);
        }
        for (int i = 0; i < 10; i++)
        {
            GameObject obj = Instantiate(laserLauncher);
            obj.SetActive(false);
            laserLauncherPool.Enqueue(obj);
        }
        for (int i = 0; i < 10; i++)
        {
            GameObject obj = Instantiate(obstacle[Random.Range(0,obstacle.Length)]);
            obj.SetActive(false);
            obstaclePool.Enqueue(obj);
        }

    }


    // her poolda çalýþacak, istenen yerde pool belirtilmeli


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(SpawnObject());
    }

    
    IEnumerator SpawnObject()
    {
        // 5snde bir  2-5 arasý düþman
        // 3snde bir 2-3 arasý düþman
        // 1.2f snde bir 2-3 arasý düþman
        // altýn dalgasý
        // dalgalar rasgele olacak her dalga tamamlandýðýnda 1sn timer( altýn da düþman gibi rasgele)

        while (true)
        {

        

        yield return new WaitForSeconds(1);
        int enemyCount = Random.Range(2, 5);
        float spawnRate = Random.Range(.5f, 1.9f);
        int randomizer = 1;

        if(randomizer==0)
        {
            //altýn
            GameObject goldWave = GetPooledObject(coinWavePool);
            goldWave.transform.position = new Vector3(0, .5f, player.position.z + 60);
        }
        else if(randomizer==1)
        {
            //launcher
            for (int i = 0; i < enemyCount; i++)
            {
                GameObject launcher = GetPooledObject(laserLauncherPool);
                launcher.transform.position = new Vector3(Random.Range(-launcherXPosLimit,launcherXPosLimit), 1.7f, player.position.z + 60);
                yield return new WaitForSeconds(spawnRate);
            }

        }
        else if(randomizer==2)
        {
            //obstacle
        }



        }

    }








    public GameObject GetPooledObject(Queue<GameObject> q)
    {
        GameObject obj = q.Dequeue();
        obj.SetActive(true);
        q.Enqueue(obj);
        return obj;
    }



}
