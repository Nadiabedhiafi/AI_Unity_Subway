using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,3);
    }

    
    void Update()
    {
        
    }
}
