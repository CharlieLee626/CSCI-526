using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject[] pauseObjects;

    public void Start()
    {
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        GameObject.Find("GameOver").SetActive(GameOver.IsGameOver);
        if (GameOver.IsGameOver)
        {
            Time.timeScale = 0;
            hidePaused();
        }
        else
        {
            Time.timeScale = 1;
            GameOver.IsGameOver = false;
            if (Paused.IsPaused)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else
            {
                Time.timeScale = 1;
                Paused.IsPaused = false;
                hidePaused();
            }
        }
        
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync("Menu");
    }

    public void PlayGame()
    {
        GameOver.IsGameOver = false;
        Paused.IsPaused = false;
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game");
        #if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    //shows objects with ShowOnPause tag
    void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    //hide objects with ShowOnPause tag
    void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }
}

public static class Paused
{
    public static bool IsPaused { get; set; }
}

public static class GameOver
{
    public static bool IsGameOver { get; set; }
}
