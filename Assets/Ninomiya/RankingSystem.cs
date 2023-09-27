using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


[System.Serializable]
public class PlayerScore : IComparable<PlayerScore>
{
    public float _score = 100;

    public PlayerScore(float score)
    {
        this._score = score;
    }

    public int CompareTo(PlayerScore other)
    {
        return _score.CompareTo(other._score);
    }
}

[System.Serializable]
public class ScoreData
{
    public List<PlayerScore> _scores;

    public ScoreData()
    {
        _scores = new List<PlayerScore>();
        for(int i = 0; i < 5; i++)
        {
            _scores.Add(new PlayerScore(999.9f));
        }
    }

    public void AddScore(float score)
    {
        PlayerScore newScore = new PlayerScore(score);
        _scores.Add(newScore);
        _scores.Sort();
    }
}
public class RankingSystem : MonoBehaviour
{
    [SerializeField, Header("ジェイソンファイルの名前")] string _jsonFileName;

    ScoreData _scoreData;

    private void Awake()
    {
        LoadScore();
    }

    public void AddPlayerScore(float score)
    {
        _scoreData.AddScore(score);
        SaveScore();
    }

    public List<PlayerScore> GetScores(int count)
    {
        return _scoreData._scores.GetRange(0, Mathf.Min(count, _scoreData._scores.Count));
    }

    private void LoadScore()　//スコアの読み込み
    {
        string filePath = Path.Combine(Application.persistentDataPath, _jsonFileName);

        if(File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            _scoreData = JsonUtility.FromJson<ScoreData>(json);
        }
        else
        {
            _scoreData = new ScoreData();
        }
    }

    public void SaveScore() //現在のスコアを保存する
    {
        string filePath = Path.Combine(Application.persistentDataPath, _jsonFileName);
        string json = JsonUtility.ToJson(_scoreData);
        File.WriteAllText(filePath, json);
    }

    public List<PlayerScore> GetRanking(int count)
    {
        return GetScores(count);
    }
}
