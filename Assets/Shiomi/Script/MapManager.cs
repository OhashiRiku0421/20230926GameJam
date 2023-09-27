using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    //ミニマップの要素
    [SerializeField] Slider _slider;
    /// <summary>それぞれのゴールの位置を保存</summary>
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
    public Transform GoalPos => _goalPos;

    private void Awake()
    {
        //スライダーを初期化
        _slider.value = 0;
        //ゴールの位置を決定する
        _goalPos = _setGoalsPos[Random.Range(0, 3)];


    }
    void Start()
    {
        //設定された位置にマークする
        _markObjects[Random.Range(0, 3)].GetComponent<Image>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //スライダーの値を更新
        _slider.value = _player.transform.position.x / _setGoalsPos[2].transform.position.x;
        //Debug.Log(_slider.value);
        if(_slider.value >= _firstAnnounce || _firstActive)
        {
            //アナウンス処理
            _announcementController.AnimationPlay();
            _firstActive = false;
        }

        if(_slider.value >= _secondAnnounce || _secondActive)
        {
            //アナウンス処理
            _announcementController.AnimationPlay();
            _secondActive = false;
        }

        if(_slider.value >= _thirdAnnounce || _thirdActive)
        {
            //アナウンス処理
            _announcementController.AnimationPlay();
            _thirdActive = false;
        }
    }
}
