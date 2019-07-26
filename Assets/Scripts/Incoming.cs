using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incoming : MonoBehaviour
{
    public Rigidbody rb;
    public float fwd;
    public float expand;

    void Update()
    {
        rb.AddForce(0, 0, - fwd * Time.deltaTime, ForceMode.VelocityChange);
    }
}
