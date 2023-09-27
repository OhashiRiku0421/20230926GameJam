using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


[System.Serializable]
public class PlayerScore : IComparable<PlayerScore>
{
    public float _score;

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
    public List<PlayerScore> _scores = new List<PlayerScore>();

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
        LordScore();
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

    private void LordScore()　//スコアの読み込み
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

    private void SaveScore() //現在のスコアを保存する
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
