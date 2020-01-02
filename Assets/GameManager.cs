
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isAlive = true;
    public void GameOver()
    {
        isAlive = false;
        CollisionAndScore.Score = 0;
        Invoke("Restart", 2f);

    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /*public void GameOver()
    {
        StartCoroutine(Restart());
    }
    IEnumerator Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        yield return new WaitForSeconds(2f);
    }*/
}
