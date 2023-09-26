using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>速度</summary>
    [SerializeField] float _speed = default;
    /// <summary>速度上限</summary>
    [SerializeField] float _speedMax;
    /// <summary>Player(ドア)のposition</summary>
    [SerializeField] Transform _positionP;
    /// <summary>ホームドアのposition</summary>
    [SerializeField] Transform _positionH;
    /// <summary>右に移動</summary>
    Vector2 velo = Vector2.right; 
    Rigidbody2D _rb;
    /// <summary>移動しているかの判定</summary>
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
        /// <summary>車両ドアとホームドアの距離</summary>
        float d = _positionH.position.x - _positionP.position.x;
        return d;
    }
}
