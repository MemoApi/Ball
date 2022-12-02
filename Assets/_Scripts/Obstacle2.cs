using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle2 : MonoBehaviour
{
    public float speed;
    private float randomStart;
    private float mapLimit;

    private void Start()
    {
        randomStart = Random.Range(1, 3);
        mapLimit = 6.5f;
        speed = 1.5f;
    }
    //6.5
    private void Update()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Sin(Time.time * speed * randomStart) * mapLimit;
        transform.position = pos;
    }




}
