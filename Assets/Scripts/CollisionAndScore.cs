using UnityEngine;
using UnityEngine.UI;
public class CollisionAndScore : MonoBehaviour
{
    public static int Score = 0;
    public Text scoreText;
    public float incoming;
    private bool pushBack;
    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(Score.ToString());
        if (collision.gameObject.tag == "Point")
        {
            Destroy(collision.gameObject);
            Score++;
            //Destroy(collision.collider);
        }
        else if (collision.gameObject.tag == "Wall")
        {
            /*GetComponent<Inputs>().enabled = false;
            FindObjectOfType<GameManager>().GameOver();*/
            gameObject.GetComponent<Rigidbody>().AddForce(0, 0, -incoming * Time.deltaTime, ForceMode.VelocityChange);
            pushBack = true;
            Debug.Log("Hitting Wall");
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            /*GetComponent<Inputs>().enabled = false;
            FindObjectOfType<GameManager>().GameOver();*/
            pushBack = true;
            //Debug.Log("Hitting Wall");
        }
    }
    void OnCollisionExit(Collision collision)
    {
        pushBack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pushBack)
        {
            transform.localPosition -= new Vector3(0, 0, incoming);
            Debug.Log("Hitting Wall");
        }
        scoreText.text = (Score/2).ToString();
        //Debug.Log(Score.ToString());
    }
}
