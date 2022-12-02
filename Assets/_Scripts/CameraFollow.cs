using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offSet;

    private void Start()
    {
        
    }

    private void LateUpdate()
    {
        //4.71
        //-17.9
        transform.position = player.transform.position + offSet;
    }


}
