using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incoming : MonoBehaviour
{
    private Rigidbody rb;
    public float fwd;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Debug.Log("moving");
        rb.AddForce(0, 0, -fwd * Time.deltaTime, ForceMode.VelocityChange); 
        
        /*if (rb.position.z == -5)
        {
            Destroy(gameObject);
        }*/
    }
}
