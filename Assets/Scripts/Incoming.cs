using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incoming : MonoBehaviour
{
    public Rigidbody rb;
    public float fwd;

    void Update()
    {
        try {
            rb.AddForce(0, 0, -fwd * Time.deltaTime, ForceMode.VelocityChange); }
        catch ( UnassignedReferenceException)
        { }
        if (rb.position.z == -5)
        {
            Destroy(gameObject);
        }
    }
}
