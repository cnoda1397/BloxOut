using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Incoming : MonoBehaviour
{
    private Rigidbody rb;
    float fwd;
    void Awake()
    {
        fwd = FindObjectOfType<ProceduralGeneration>().fwd;
        //Debug.Log("speed = " + fwd);
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Debug.Log("moving");
        rb.AddForce(0, 0, -fwd * Time.deltaTime, ForceMode.VelocityChange); 
        
        if (rb.position.z <= -25)
        {
            Destroy(gameObject);
        }
    }
}
//FindObjectOfType<ProceduralGeneration>().spawnCount