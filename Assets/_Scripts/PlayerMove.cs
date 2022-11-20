using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{


    //Hareket deðiþkenleri
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    private Vector3 playerStartPos;
    


    private void OnEnable()
    {
        EventManager.ObstacleCollided += PlayerBackToStart;
        EventManager.GameFinished += PlayerStop;
    }
  

    private void Start()
    {
        speed = 10;
        turnSpeed = 15;
        playerStartPos = transform.position;
        
        
    }

    void Update()
    {
        Move();   
    }


    // Yatay ve Dikey Hareket
    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 move = new Vector3(horizontal * turnSpeed, 0, speed);

        transform.Translate(move * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -6.5f, 6.5f), transform.position.y, transform.position.z);
    }

    private void PlayerStop()
    {
        speed = 0;
        turnSpeed = 0;
    }

    private void PlayerBackToStart()
    {
        transform.position = playerStartPos;
    }
   

    // Altýnla, Engelle ve Bitiþ ile Çarpýþma
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            EventManager.Instance.CoinCollision();           
            StartCoroutine(coin(other.gameObject));
        }       
        if (other.CompareTag("Obstacle"))
        {
            EventManager.Instance.ObstacleCollision();           
        }
        if (other.CompareTag("Finish"))
        {
            EventManager.Instance.GameFinish();           
        }

    }

    IEnumerator coin(GameObject coin)
    {
        coin.SetActive(false);
        yield return new WaitForSeconds(1);
        coin.SetActive(true);
    }


    private void OnDisable()
    {
        EventManager.ObstacleCollided -= PlayerBackToStart;
        EventManager.GameFinished -= PlayerStop;
    }

}
