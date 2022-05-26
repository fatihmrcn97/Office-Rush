using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 offSet;

    public GameObject player;
  
    void Update()
    {
        transform.position = player.transform.position + offSet;
    }
}
