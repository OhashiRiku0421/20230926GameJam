using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = default;
    [SerializeField] Transform _positionP;
    [SerializeField] Transform _positionH;
    [SerializeField] float _speedMax;
    Vector2 velo = Vector2.right; 
    Rigidbody2D _rb;
    bool _isMove = true;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (_isMove)
        {
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
        float d = _positionH.position.x - _positionP.position.x;
        return d;
    }
}
