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

    public void ContinueGame()
    {
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync(2);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(0); // 0 represents SampleScene. Mapped to build settings
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
