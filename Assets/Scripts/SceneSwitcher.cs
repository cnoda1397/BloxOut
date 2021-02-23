using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    // Start is called before the first frame update
    public static void GoToGame()
    {
        Debug.Log("Button Clicked");
        SceneManager.LoadScene("GameScene");
        
    }
    public void GoToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public static void GoToHome()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
}
