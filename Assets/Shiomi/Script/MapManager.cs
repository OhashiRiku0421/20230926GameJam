using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    //�~�j�}�b�v�̗v�f
    [SerializeField] Slider _slider;
    /// <summary>���ꂼ��̃S�[���̈ʒu��ۑ�</summary>
    [SerializeField] GameObject _player;
    /// <summary>���ꂼ��̃S�[���̈ʒu��ۑ�</summary>
    [SerializeField] Transform[] _setGoalsPos;
    /// <summary>���肵���S�[���ʒu</summary>
    Transform _goalPos;

    /// <summary>�}�[�N�̃I�u�W�F�N�g</summary>
    [SerializeField] GameObject[] _markObjects;

    /// <summary>�~�j�}�b�v�p�̃S�[���C���[�W</summary>
    //[SerializeField] GameObject _goalImage;

    /// <summary>�X���C�_�[�̒[��RectTransform</summary>
    //RectTransform _rstartPos;
    //RectTransform _rendPos;

    /// <summary>�A�i�E���X����</summary>
    bool _firstActive, _secondActive, _thirdActive = true;
    [SerializeField] float _firstAnnounce = 0.2f;
    [SerializeField] float _secondAnnounce = 0.5f;
    [SerializeField] float _thirdAnnounce = 0.9f;

    [SerializeField] AnnouncementTextAnimationController _announcementController;
    public Transform GoalPos => _goalPos;

    private void Awake()
    {
        //�X���C�_�[��������
        _slider.value = 0;
        //�S�[���̈ʒu�����肷��
        _goalPos = _setGoalsPos[Random.Range(0, 3)];


    }
    void Start()
    {
        //�ݒ肳�ꂽ�ʒu�Ƀ}�[�N����
        _markObjects[Random.Range(0, 3)].GetComponent<Image>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //�X���C�_�[�̒l���X�V
        _slider.value = _player.transform.position.x / _setGoalsPos[2].transform.position.x;
        //Debug.Log(_slider.value);
        if(_slider.value >= _firstAnnounce || _firstActive)
        {
            //�A�i�E���X����
            _announcementController.AnimationPlay();
            _firstActive = false;
        }

        if(_slider.value >= _secondAnnounce || _secondActive)
        {
            //�A�i�E���X����
            _announcementController.AnimationPlay();
            _secondActive = false;
        }

        if(_slider.value >= _thirdAnnounce || _thirdActive)
        {
            //�A�i�E���X����
            _announcementController.AnimationPlay();
            _thirdActive = false;
        }
    }
}
