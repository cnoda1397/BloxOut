using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    public Rigidbody rb;
    private float sdway = 75f;
    private float expand = .1f;
    private bool once = true;

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(rb.position.y - rb.transform.localScale.y/2);
        /*if player in in mid air, bring it down
        if(rb.position.y-rb.transform.localScale.y > 1.01f)
        {
            rb.AddForce(0, -9.8f, 0, ForceMode.VelocityChange);
        }//*/
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
            rb.AddForce(0, -9.8f, 0, ForceMode.VelocityChange);
            rb.velocity = Vector3.zero;
            rb.AddForce(0, 0, 0, ForceMode.VelocityChange);
        }

        //Resizing
        if (Input.GetKey("up"))
        {
            transform.localScale += new Vector3(0, expand, 0);
        }
        if (Input.GetKey("right"))
        {
            transform.localScale += new Vector3(expand, 0, 0);
        }

        if (rb.transform.localScale.y >= .5)
        {
            if (Input.GetKey("down"))
            {
                transform.localScale -= new Vector3(0, expand, 0);
                transform.localPosition -= new Vector3(0, expand, 0);
            }
        }
        if (rb.transform.localScale.x >= .5) { 
            if (Input.GetKey("left"))
            {
                transform.localScale -= new Vector3(expand, 0, 0);
            }
        }
        if (transform.localPosition.y < 0.5)
        {
            if (once)
            {
                once = false;
                rb.freezeRotation = false;
                GetComponent<AudioSource>().Play();
                FindObjectOfType<GameManager>().GameOver();
            }
            rb.AddTorque(new Vector3(1f, 1f, 0));
            
        }
        if (Input.GetKey("r") && transform.localPosition.z > -25)
        {
            rb.transform.localScale = new Vector3(1f, 1f, 1f);
            rb.transform.localPosition = new Vector3(0f, 1f, rb.transform.localPosition.z);
        }
    }
}
