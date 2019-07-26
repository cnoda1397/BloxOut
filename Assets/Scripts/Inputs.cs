using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    public Rigidbody rb;
    public float sdway = 2000f;
    public float fwd = 2000f;
    public float expand = .1f;


    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(rb.position.y - rb.transform.localScale.y/2);
        //if player in in mid air, bring it down
        if(rb.position.y-rb.transform.localScale.y > 1.01f)
        {
            rb.AddForce(0, -9.8f, 0, ForceMode.VelocityChange);
        }
        //Lateral Movements
        if (Input.GetKey("d"))
        {
            rb.AddForce(sdway * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        else if (Input.GetKey("a"))
        {
            rb.AddForce(-sdway * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        else if (!Input.GetKey("a") && !Input.GetKey("d"))
        {
            //rb.AddForce(0, -9.8f, 0, ForceMode.VelocityChange);
            rb.velocity = Vector3.zero;
            //rb.AddForce(0, 0, 0, ForceMode.VelocityChange);
        }

        //Resizing
        if (Input.GetKey("up"))
        {
            transform.localScale += new Vector3(0, expand, 0);
        }
        if (Input.GetKey("down"))
        {
            transform.localScale -= new Vector3(0, expand, 0);
        }

        if (Input.GetKey("right"))
        {
            transform.localScale += new Vector3(expand, 0, 0);
        }
        if (Input.GetKey("left"))
        {
            transform.localScale -= new Vector3(expand, 0, 0);
        }
    }
}
