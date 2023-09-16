using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class PlayerCheckPoint : MonoBehaviour
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
            _anim.SetTrigger("CheckT");
            _PlayerController.CheckPointUp(_respawnpos.position);
            _anim.SetTrigger("CheckL");

        }
    }
}
