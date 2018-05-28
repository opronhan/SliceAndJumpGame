using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System;
public class GamePlayController : MonoBehaviour { 
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private GameObject diePanel;
    [SerializeField]
    private GameObject finishPanel;
    [SerializeField]
    private GameObject outGamePanel;
    private Button button;
    [SerializeField]
    private Button resumeGame;
    [SerializeField]
    private Button resetGame;
    private Text score;
    private Text inputname;
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
        diePanel.SetActive(true);
        resetGame.onClick.RemoveAllListeners();
        resetGame.onClick.AddListener(() => RestartGame());
    }
    public void PlayerFinish()
    {
        Time.timeScale = 0f;
        finishPanel.SetActive(true);
    }
    public void showOutPanel()
    {
        pausePanel.SetActive(false);
        diePanel.SetActive(false);
        finishPanel.SetActive(false);
        outGamePanel.SetActive(true);
    }
    public void GoMainMenu()
    {
        Time.timeScale = 1f;
        score = GameObject.Find("Score").GetComponent<Text>();
        inputname = GameObject.Find("inputnametxt").GetComponent<Text>();
        //database
        string conn = "URI=file:" + Application.dataPath + "/GameDatabase.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        
        String sqlQuery = "INSERT INTO player (score, name) VALUES ("+int.Parse(score.text)+", '"+inputname.text+"');";
       
        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteNonQuery();
        dbconn.Close();
        //close
        Application.LoadLevel("MainMenu");
    }

}
