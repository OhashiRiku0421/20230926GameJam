using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = default;
    [SerializeField] Transform _positionP;
    [SerializeField] Transform _positionH;
    Vector2 velo = Vector2.right; 
    Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rb.AddForce(velo * _speed);
        if(_positionH.position.x > _positionP.position.x && Input.GetButtonDown("Stop"))
        {
            _rb.velocity = Vector2.zero;
            _speed = 0;

            Debug.Log(Distance());
        }
    }
    float Distance()
    {
        float d = _positionH.position.x - _positionP.position.x;
        return d;
    }
}
