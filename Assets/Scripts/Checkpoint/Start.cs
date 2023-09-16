using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{
    PlayerController _PlayerController;
    public Transform _respawnpos;
    Animator _anim;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _PlayerController = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            _anim.SetTrigger("move");
            _PlayerController.CheckPointUp(_respawnpos.position);
        }
    }
}
