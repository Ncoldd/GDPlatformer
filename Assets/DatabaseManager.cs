using SQLite;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using UnityEngine;

public class HighScore
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    
    public string PlayerName { get; set; }
    public int Score { get; set; }
    public float CompletionTime { get; set; }
}

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager Instance { get; private set; }

    private string dbPath;
    private SQLiteConnection dbConnection;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        SetDatabasePath();
        InitializeDatabase();
    }

    void SetDatabasePath()
    {
        dbPath = Path.Combine(Application.persistentDataPath, "gamedata.db");
    }

    void InitializeDatabase()
    {
        dbConnection = new SQLiteConnection(dbPath);
        CreateHighScoresTable();
    }

    void CreateHighScoresTable()
    {
        dbConnection.CreateTable<HighScore>();
        Debug.Log("High Scores table created at: " + dbPath);
    }
    
    public void SaveScore(string playerName, int score, float completionTime)
    {
        HighScore newScore = new HighScore
        {
            PlayerName = playerName,
            Score = score,
            CompletionTime = completionTime
        };
        dbConnection.Insert(newScore);
        Debug.Log("Score saved: " + playerName + " - " + score);
    }

    public List<HighScore> GetTopHighScores(int count)
    {
        return dbConnection.Table<HighScore>()
            .OrderByDescending(score => score.Score)
            .Take(5)
            .ToList();
    }
}
