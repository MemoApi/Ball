using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    float speed=5;

    

    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }

    

    //triggerda sorun var kendiyle çarpýþýyor 
    private void OnTriggerEnter(Collider other)
    {
         if(other.gameObject!=transform.parent.gameObject)
        this.gameObject.SetActive(false);
    }

}
