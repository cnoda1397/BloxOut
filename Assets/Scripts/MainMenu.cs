using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject MenuObject;
    public GameObject GuideObject;
    public GameObject ScoresObject;
    public GameObject CreditsObject;
    public Text scores;


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
        //Text scores = ScoresObject.GetComponent<Text>();
        string prev = "score9";
        string key = "score9";
        for (int i = 0; i < 9; i--)
        {
            key.Replace(key[key.Length - 1], (char)i);
            //scores.text = scores.text + PlayerPrefs.GetInt(key, 0);
            prev = key;
            Debug.Log(key);
            //scores.text = scores.text + "\n";
        }
        MenuObject.SetActive(false);
        ScoresObject.SetActive(true);
    }
}
