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
        mapLimit = 6f;
        speed = 1;
    }

    private void Update()
    {
        Vector3 pos = transform.position;
        pos.y = Mathf.Abs(Mathf.Sin(Time.time * speed * randomStart) * mapLimit) + 1.25f;
        transform.position = pos;
    }




}
