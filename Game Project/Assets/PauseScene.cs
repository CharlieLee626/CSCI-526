using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseScene : MonoBehaviour
{
    public void PauseGame()
    {
        Paused.IsPaused = true;
        // 2 represents MainMenu scene. Mapped to build settings
        SceneManager.LoadScene(2, LoadSceneMode.Additive); 
    }
}
