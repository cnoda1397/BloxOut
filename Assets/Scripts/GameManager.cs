using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isAlive = true;
    public GameObject pauseMenu;
    public GameObject pauseButton;
    
    public void Awake()
    {
        Resume();
    }
    public void GameOver()
    {
        isAlive = false;
        
        int score = CollisionAndScore.Score / 4;
        int temp;
        string prev = "score9";
        string key = "score9";
        if (score > PlayerPrefs.GetInt(prev, 0))
        {
            Debug.Log("SCORE Update in effect");
            PlayerPrefs.SetInt(prev, score);
            for (int i = 8; i >= 0; i--)
            {
                key.Replace(key[key.Length - 1], (char)i);
                if (score > PlayerPrefs.GetInt(key, 0))
                {
                    temp = PlayerPrefs.GetInt(key, 0);
                    PlayerPrefs.SetInt(key, score);
                    PlayerPrefs.SetInt(prev, temp);
                    prev = key;
                }
                else break;
            }
        }
        Invoke("Restart", 3f);
        
            

    }
    public void Restart()
    {
        CollisionAndScore.Score = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Pause()
    {
        Time.timeScale = 0;

        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        Debug.Log("Game Paused");

    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    /*public static void getPrefs(Action func)
    {
        string prev = "score9";
        string key = "score9";
        for (int i = 8; i >= 0; i--)
        {
            key.Replace(key[key.Length - 1], (char)i);
            func();
            prev = key;
        }
    }*/
    
}

