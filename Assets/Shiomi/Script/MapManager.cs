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
    // Start is called before the first frame update
    void Start()
    {
        //�X���C�_�[��������
        _slider.value = 0;
        //�S�[���̈ʒu�����肷��
        //_goalPos = _setGoalsPos[0];
        //�ݒ肳�ꂽ�ʒu�Ƀ}�[�N����
        _markObjects[0].GetComponent<Image>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //�X���C�_�[�̒l���X�V
        _slider.value = _player.transform.position.x / _setGoalsPos[2].transform.position.x;
        //Debug.Log(_slider.value);
    }
}
