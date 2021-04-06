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
        /*else if (collision.gameObject.tag == "Wall")
        {
            GetComponent<Inputs>().enabled = false;
            FindObjectOfType<GameManager>().GameOver();
            //pushBack = true;
            //Debug.Log("Hitting Wall");
        }*/
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            //gameObject.GetComponent<Rigidbody>().velocity = collision.gameObject.GetComponent<Rigidbody>().velocity;
            //Debug.Log("Still this Hitting Wall");
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

    }

    // Update is called once per frame
    void Update()
    {

        scoreText.text = (Score/4).ToString();
    }
}
