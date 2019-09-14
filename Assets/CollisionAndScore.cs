using UnityEngine;
using UnityEngine.UI;
public class CollisionAndScore : MonoBehaviour
{
    public static int Score = 0;
    public Text scoreText;
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(Score.ToString());
        if(collision.gameObject.tag == "Point")
        {
            Destroy(collision.gameObject);
            Score++;
            //Destroy(collision.collider);
        }
        else if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("Game Over");
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = (Score/2).ToString();
        Debug.Log(Score.ToString());
    }
}
