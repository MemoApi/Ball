using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLauncher : MonoBehaviour
{



    LaserPool laserPool;
    float shootRate = .5f;

    private void Start()
    {
        laserPool = GetComponent<LaserPool>();

        StartCoroutine(Shoot(shootRate));
    }


   


    IEnumerator Shoot(float shootRate)
    {

        yield return new WaitForSeconds(1);

        while (true)
        {
            yield return new WaitForSeconds(shootRate);

            GameObject laser = laserPool.GetLaserObject();
            laser.transform.position = transform.position;



        }


    }

   

}
