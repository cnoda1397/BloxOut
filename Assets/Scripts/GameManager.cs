using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isAlive = true;
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public GameObject gameOverCanvas;
    public GameObject inputCanvas;

    public InputField nameInput;
    public Text playerList;
    public Text scoreList;
    public void Awake()
    {
        Resume();
    }
    public void GameOver()
    {
        pauseButton.SetActive(false);
        isAlive = false;
        int score = CollisionAndScore.Score / 4;
        if (score > PlayerPrefs.GetInt("score10", 0))
        {
            //string yourScore = "Your Score: " + score.ToString();
            //playerScore.text = yourScore;
            inputCanvas.SetActive(true);
            nameInput.onEndEdit.AddListener(setPrefs);

        }
        else Invoke("Restart", 3f);

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

    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    private void setPrefs(string arg0)
    {
        //string player = nameInput.GetComponent<Text>().text;
        string player = arg0;
        inputCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        int score = CollisionAndScore.Score / 4;
        int scoreTemp;
        string playerTemp;
        string playerPrev = "player10";
        string playerKey;
        string prev = "score10";
        string key;
        PlayerPrefs.SetInt(prev, score);
        PlayerPrefs.SetString(playerPrev, player);
        /*
         Get the values of the iterator's spot on leaderboard abd save them
         If the score is higher, set the previous spot's values to the current values (temp)
         Set the curretn values to the Player's values
         */
        for (int i = 9; i > 0; i--)
        {
            playerKey = "player" + i.ToString();
            key = "score" + i.ToString();
            scoreTemp = PlayerPrefs.GetInt(key, 0);
            playerTemp = PlayerPrefs.GetString(playerKey, "cpu");
            if (score > scoreTemp)
            {
                Debug.Log("PlayerPrev: " + playerPrev);
                PlayerPrefs.SetString(playerPrev, playerTemp);
                PlayerPrefs.SetInt(prev, scoreTemp);
                PlayerPrefs.SetString(playerKey, player);
                PlayerPrefs.SetInt(key, score);
                Debug.Log("scoreTemp: " + scoreTemp.ToString());
                prev = key;
                playerPrev = playerKey;
            }
            else break;
        }
        MainMenu.setScoreList();
        scoreList.text = MainMenu.highScores;
        playerList.text = MainMenu.playerRanks;
        
    }

}

