using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [Header("Moving")]
    private float _input;
    [SerializeField] private int _speed;
    private bool _canmove = true;
    private bool _faceR = true;
    [Header("jump")]
    [SerializeField] private int _powjump;
    private bool _canDoublejump;
    [Header("checkground")]
    private bool _isground;
    [SerializeField] private LayerMask _Whatlayerground;
    [SerializeField] private float _groundRadius;
    [Header("checkwall")]
    private bool _isWall , _checkwallR , _checkwallL;
    [SerializeField] private LayerMask _Whatlayerwall;
    [Range(0f, 10f)]
    [SerializeField] private float _wallcheckdis;
    private bool _canWallSliding;
    private bool _wallSliding;
    [Header("jumpwall")]
    private int _faceDirection = 1;
    [SerializeField] public Vector2 _walljumpDirection;
    private Rigidbody2D _rb;
    private Animator _animat;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animat = GetComponent<Animator>();
    }
    private void Update()
    {
        Collidercheck();
        collideflip();
        UpAnimator();
        checkInput();
        if (_isground)
        {
            _canmove = true;
            _canDoublejump = true;
        }
        if (_canWallSliding && !_isground)
        {
            _canmove = false;
            _wallSliding = true;
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 0.1f);
        }
        move();
    }
    #region input
    private void checkInput()
    { 
        if (_canmove) _input = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("JUMP")) jump();
        if (Input.GetAxis("Vertical") < 0) _canWallSliding = false;
    }
    #endregion
    #region jump
    void jump()
    {
        if(_wallSliding)
        {
            Walljump();
            _canmove = true;
        }
        else if (_isground) _rb.velocity = new Vector2(_rb.velocity.x, _powjump);
        else if (_canDoublejump)
        {
            _canmove = true;
            _canDoublejump=false;
            _rb.velocity = new Vector2(_rb.velocity.x, _powjump);
        }
        _canWallSliding = false;
    }
    #endregion
    #region walljump
    private void Walljump()
    {
        _canDoublejump = true;
        _canmove = false;
        _rb.velocity = new Vector2 (_walljumpDirection.x * - _faceDirection ,_walljumpDirection.y  );
    }
    #endregion
    #region move
    private void move()
    {
        if (_canmove)
        {
            _rb.velocity = new Vector2(_input * _speed, _rb.velocity.y);
        }
    }
    #endregion
    #region UpAnimator
    void UpAnimator()
    {
        bool _ismoving = _rb.velocity.x != 0;
        _animat.SetBool("Movi", _ismoving);
        _animat.SetFloat("velocity.y", _rb.velocity.y);
        _animat.SetBool("isground", _isground);
        _animat.SetBool("wallsliding", _wallSliding);
    }
    #endregion
    #region flip
    void flip () 
    {
        _faceDirection = _faceDirection * -1 ;
        Vector3 _currentsacle = transform.localScale;
        _currentsacle.x *= -1;
        transform.localScale = _currentsacle;
        _faceR = !_faceR;
    }
    private void collideflip()
    {
        if(_isground && _isWall)
        {
            if(_faceR && _input < 0) flip();
            else if(!_faceR && _input > 0) flip();
        }
        if(_input > 0 && !_faceR ) flip();
        else if(_input < 0 && _faceR) flip();
    }
    #endregion
    #region check ground and wall
    private void Collidercheck()
    {
        _isground = Physics2D.Raycast(transform.position, Vector2.down, _groundRadius, _Whatlayerground);
        _checkwallR = Physics2D.Raycast(transform.position, Vector2.right, _wallcheckdis, _Whatlayerwall);
        _checkwallL = Physics2D.Raycast(transform.position, Vector2.left, _wallcheckdis, _Whatlayerwall);
        if(_checkwallR || _checkwallL) _isWall = true;
        else _isWall = false;
        if (_isWall && _rb.velocity.y <0) _canWallSliding = true;
        if (!_isWall) 
        {
            _canWallSliding = false;
            _wallSliding = false;
        }    
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + _wallcheckdis, transform.position.y));
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x , transform.position.y - _groundRadius));
    }
    #endregion
}
