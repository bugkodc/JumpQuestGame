using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class chiken : MonoBehaviour
{
    private Rigidbody2D _Rb;
    [SerializeField] private float _speed;
    bool _checkplayer;
    [Range(0, 5)]
    [SerializeField] private float _groundRadius;
    [SerializeField] private LayerMask _Whatlayerground;
    [SerializeField] private float _pos1;
    [SerializeField] private float _pos2;
    bool _faceR = true;
    int _faceDirection = 1;
    Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _Rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Collidercheck();
        move();
    }
    private void move()
    {
        if (transform.position.x > _pos1)
        {
            _Rb.velocity = new Vector2(_speed * _faceDirection , _Rb.velocity.y);
            if (transform.position.x > _pos2)
            {
                flip();
                _Rb.velocity = new Vector2(_speed * _faceDirection, _Rb.velocity.y);
            } 
        }            
        else
        {
            flip();
            _Rb.velocity = new Vector2(_speed * _faceDirection, _Rb.velocity.y);
        }
    }
   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player")) Die();
    }
   void Die()
    {
        Destroy(gameObject);
    }*/
    void flip()
    {
        _faceDirection = _faceDirection * -1;
        Vector3 _currentsacle = transform.localScale;
        _currentsacle.x *= -1;
        transform.localScale = _currentsacle;
        _faceR = !_faceR;
    }
    private void Collidercheck()
    {
        _checkplayer = Physics2D.Raycast(transform.position, Vector2.up, _groundRadius, _Whatlayerground);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x , transform.position.y+ _groundRadius));
    }
}
