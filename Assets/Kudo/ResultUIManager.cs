using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUIManager : MonoBehaviour
{
    [SerializeField] Text[] _rankingScores;
    [SerializeField] Text _MyScore;
    RankingSystem _rankingSystem;
    private void Start()
    {
        float myScore = GameManager.GoalDistance;
        _rankingSystem = FindObjectOfType<RankingSystem>();
        var h = _rankingSystem.GetRanking(myScore, 5);
        for(int i = 0; i < h.Count; i++)
        {
            _rankingScores[i].text = $"{i+1}ˆÊ {h[i]._score.ToString("00")}";
        }
        _MyScore.text = myScore < 0 ? "" : $"{myScore.ToString("00")}";
    }
}
    
