using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour { 
    [SerializeField]
    private GameObject pausePanel;
    private Button button;
    [SerializeField]
    private Button resumeGame;

    public void pauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        resumeGame.onClick.RemoveAllListeners();
        resumeGame.onClick.AddListener(()=>ResumeGame());
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }
    public void RestartGame() {
        Time.timeScale = 1f;
        Application.LoadLevel("SceneOne");
    }
    public void PlayerDied()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        resumeGame.onClick.RemoveAllListeners();
        resumeGame.onClick.AddListener(() => RestartGame());
    }
    public void GoMainMenu()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("MainMenu");
    }
}
