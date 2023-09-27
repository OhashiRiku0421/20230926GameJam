using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    //ミニマップの要素
    [SerializeField] Slider _slider;
    [SerializeField] GameObject _player;
    /// <summary>それぞれのゴールの位置を保存</summary>
    [SerializeField] Transform[] _setGoalsPos;
    /// <summary>決定したゴール位置</summary>
    Transform _goalPos;

    /// <summary>マークのオブジェクト</summary>
    [SerializeField] GameObject[] _markObjects;

    /// <summary>ミニマップ用のゴールイメージ</summary>
    //[SerializeField] GameObject _goalImage;

    /// <summary>スライダーの端のRectTransform</summary>
    //RectTransform _rstartPos;
    //RectTransform _rendPos;

    /// <summary>アナウンス判定</summary>
    bool _firstActive, _secondActive, _thirdActive = true;
    [SerializeField] float _firstAnnounce = 0.2f;
    [SerializeField] float _secondAnnounce = 0.5f;
    [SerializeField] float _thirdAnnounce = 0.9f;

    [SerializeField] AnnouncementTextAnimationController _announcementController;
    int _count;
    public Transform GoalPos => _goalPos;

    private void Awake()
    {
        //スライダーを初期化
        _slider.value = 0;
        _count = Random.Range(0, 3);
        //ゴールの位置を決定する
        _goalPos = _setGoalsPos[_count];


    }
    void Start()
    {
        //設定された位置にマークする
        _markObjects[_count].GetComponent<Image>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //スライダーの値を更新
        _slider.value = _player.transform.position.x / _setGoalsPos[_setGoalsPos.Length - 1].transform.position.x;
        if(_slider.value > 1)
        {
            _slider.value = 1;
        }
        //Debug.Log(_slider.value);
        if(_slider.value >= _firstAnnounce && _firstActive)
        {
            Announce(0);
            _firstActive = false;
        }

        if(_slider.value >= _secondAnnounce && _secondActive)
        {
            //アナウンス処理
            Announce(1);
            _secondActive = false;
        }

        if(_slider.value >= _thirdAnnounce && _thirdActive)
        {
            //アナウンス処理
            Announce(2);
            _thirdActive = false;
        }
    }

    void Announce(int count)
    {
        //アナウンス処理
        if (_goalPos == _setGoalsPos[count])
        {
            //目的地の場合
            _announcementController.AnimationPlay("まもなく、到着いたします。お忘れ物ございませんようお気を付けください。");
        }
        else
        {
            //通過する場合
            _announcementController.AnimationPlay("まもなく、通過いたします。");
        }
    }
}
