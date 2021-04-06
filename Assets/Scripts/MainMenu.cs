using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject MenuObject;
    public GameObject GuideObject;
    public GameObject ScoresObject;
    public GameObject CreditsObject;
    public Text scores;
    public Text players;
    public static string highScores = "";
    public static string playerRanks = "";

    public void Awake()
    {
        setScoreList();
        scores.text = highScores;
        players.text = playerRanks;
    }
    public void StartGame()
    {
        SceneSwitcher.GoToGame();
    }
    public void StopGame()
    {
        SceneSwitcher.GoToHome();
    }
    public void Guide()
    {
        MenuObject.SetActive(false);
        GuideObject.SetActive(true);
    }
    public void Credits()
    {
        MenuObject.SetActive(false);
        CreditsObject.SetActive(true);
    }
    public void ReturnToMenu()
    {
        MenuObject.SetActive(true);
        GuideObject.SetActive(false);
        ScoresObject.SetActive(false);
        CreditsObject.SetActive(false);
    }
    
    public void Scores()
    {
        scores.text = highScores;
        players.text = playerRanks;
        MenuObject.SetActive(false);
        ScoresObject.SetActive(true);
    }
    public static void setScoreList()
    {
        string playerKey;
        string key;
        string scoreList = "";
        string playerList = "";
        for (int i = 1; i < 11; i++)
        {
            key = "score" + i.ToString();
            playerKey = "player" + i.ToString();
            scoreList = scoreList + PlayerPrefs.GetInt(key, 0).ToString() + '\n';
            playerList = playerList + i.ToString() + ". " + PlayerPrefs.GetString(playerKey, "cpu") + '\n';
        }
        highScores = scoreList;
        playerRanks = playerList;
    }
    public void resetPrefs()
    {
        PlayerPrefs.DeleteAll();
        setScoreList();
    }
}

//i.ToString() + ". " + 