using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.UI;
public class MainMenuController : MonoBehaviour {
    [SerializeField]
    private GameObject highscorePanel;
    private Text scoretext;
    private String scoretxt;
    public void Start()
    {
        //database
        string conn = "URI=file:" + Application.dataPath + "/GameDatabase.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT ID, score, name FROM player order by score desc, ID desc LIMIT 5"; //Hien toi da high score cua 5 nguoi cao nhat
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {

            int score = reader.GetInt32(1);
            string name = reader.GetString(2);

            scoretxt += "Name: "+name+" , Điểm: "+score+" point"+"\n";
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
        //close
        
    }
    public void PlayGame()
    {
        Application.LoadLevel("SceneOne");
    }
    public void HighScorePanel()
    {
        Time.timeScale = 0f;
        highscorePanel.SetActive(true);
        scoretext = GameObject.Find("ScoreField").GetComponent<Text>();
        scoretext.text = scoretxt;
    }
    public void TurnOffHighScorePanel()
    {
        Time.timeScale = 1f;
        highscorePanel.SetActive(false);
    }
    public void ClickExit()

    {
        Application.Quit();
    }
}
