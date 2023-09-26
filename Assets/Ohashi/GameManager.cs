using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private KeyCode _startKey = KeyCode.Space;

    [SerializeField]
    private Image _startPanel;

    [SerializeField]
    private Text _timerText;

    private ResultType _resultType;

    public ResultType GameResult { get => _resultType; set => _resultType = value; }

    private float _startTimer = 5.5f;

    public static float GoalDistance;

    private void Update()
    {
        GameStart();
        if (_startTimer > 1 && !_startPanel.enabled)
        {
            _startTimer -= Time.deltaTime;
            SetText();
        }
        else if(_startTimer < 1.00f && !_startPanel.enabled)
        {
            _timerText.enabled = false;
        }
    }

    private void SetText()
    {
        _timerText.text = _startTimer.ToString("0");

    }

    private void GameStart()
    {
        if (Input.GetKeyDown(_startKey))
        {
            _startPanel.DOFade(0, 0.5f)
                .OnComplete(() => _startPanel.enabled = false);
        }
    }

    /// <summary>
    /// タイマーが0になったらTrueを返す
    /// </summary>
    public bool StartTImer()
    {
        if (_startTimer > 0.00f)
        {
            return false;
        }
        return true;
    }
}

public enum ResultType
{
    GameClear,
    GameOver
}
