using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>���x</summary>
    [SerializeField] float _speed = default;
    /// <summary>���x���</summary>
    [SerializeField] float _speedMax;
    /// <summary>Player(�h�A)��position</summary>
    [SerializeField] Transform _positionP;
    /// <summary>�z�[���h�A��position</summary>
    [SerializeField] Transform _positionH;
    /// <summary>�E�Ɉړ�</summary>
    Vector2 velo = Vector2.right; 
    Rigidbody2D _rb;
    /// <summary>�ړ����Ă��邩�̔���</summary>
    bool _isMove = true;
    [SerializeField] GameManager _gameManager;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (_isMove)
        {
            if(_gameManager.IsTimer() == true)
            _rb.AddForce(velo * _speed);
            Debug.Log(_rb.velocity.magnitude);  
            if(_rb.velocity.magnitude < _speedMax)
            {
                _rb.velocity = _rb.velocity.normalized * _speedMax;
               
            }
        }
        if(_positionH.position.x > _positionP.position.x && Input.GetButtonDown("Stop"))
        {
            _isMove = false;
        }
        if(_rb.velocity.magnitude <= 0 )
        {
            Debug.Log(Distance());
        }
    }
    float Distance()
    {
        /// <summary>�ԗ��h�A�ƃz�[���h�A�̋���</summary>
        float d = _positionH.position.x - _positionP.position.x;
        return d;
    }
}
