using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseScene : MonoBehaviour
{
    public void PauseGame()
    {
        Paused.IsPaused = true;
        GameOver.IsGameOver = false;
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive); 
    }
}
