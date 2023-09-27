using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    /// <summary>���x</summary>
    [SerializeField] float _speed = default;
    /// <summary>���x���</summary>
    [SerializeField] float _speedMax;
    /// <summary>Player(�h�A)��position</summary>
    [SerializeField] Transform _positionP; 
    /// <summary>�z�[���h�A��position</summary>
    private Transform _positionH;
    [SerializeField]
    private FadeSystem _fadeSystem;
    /// <summary>�E�Ɉړ�</summary>
    Vector2 velo = Vector2.right; 
    Rigidbody2D _rb;
    /// <summary>�ړ����Ă��邩�̔���</summary>
    bool _isMove = true;
    AudioSource sounds;
    [SerializeField] AudioClip[] _clips; 
    bool _isClipChange = false;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _positionH = FindObjectOfType<MapManager>().GoalPos;
        sounds = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (_isMove)
        {
            if(_gameManager.IsTimer() == true)
            {
                if(_isClipChange == false)
                {
                    AudioControll(_clips[0]);
                    _isClipChange=true;
                }
                _rb.AddForce(velo * _speed);
            }
            
            
            if(_rb.velocity.magnitude < _speedMax)
            {
                _rb.velocity = _rb.velocity.normalized * _speedMax;
                AudioControll(_clips[1]);
            }
        }
        if(_positionH.position.x > _positionP.position.x && Input.GetButtonDown("Stop"))
        {
            _isMove = false;
            AudioControll(_clips[2]);
        }
        if(_rb.velocity.magnitude <= 0 )
        {
           // Debug.Log(Distance());
        }
        //Debug.Log(_rb.velocity.magnitude);
        GameOver();
        GameClear();
    }
    private void GameOver()
    {
        if(_positionH.position.x < _positionP.position.x)
        {
            GameManager.GoalDistance = Distance();
            _fadeSystem.FadeOut("GameOverScene");
        }
    }
    private void GameClear()
    {
        if(!_isMove && _gameManager.IsTimer() && _rb.velocity.magnitude <= 0)
        {
            Debug.Log("Clear");
            GameManager.GoalDistance = Distance();
            _fadeSystem.FadeOut("ResultScene");
        }
    }
    public float Distance()
    {
        /// <summary>�ԗ��h�A�ƃz�[���h�A�̋���</summary>
        float d = _positionH.position.x - _positionP.position.x;
        return d;
    }
    void AudioControll(AudioClip clip)
    {
        sounds.clip = clip;
        sounds.Play();
    }
}
