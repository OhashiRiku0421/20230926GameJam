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
    // Start is called before the first frame update
    void Start()
    {
        //スライダーを初期化
        _slider.value = 0;
        //ゴールの位置を決定する
        //_goalPos = _setGoalsPos[0];
        //設定された位置にマークする
        _markObjects[0].GetComponent<Image>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //スライダーの値を更新
        _slider.value = _player.transform.position.x / _setGoalsPos[2].transform.position.x;
        //Debug.Log(_slider.value);
    }
}
