using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public static int score = 0;
    public Text scoreText;

    void Update()
    {
        scoreText.text = score.ToString();
    }
}
