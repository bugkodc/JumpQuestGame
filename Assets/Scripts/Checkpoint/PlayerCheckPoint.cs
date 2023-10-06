using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCheckPoint : MonoBehaviour
{
    PlayerController _PlayerController;
    public Transform _respawnpos;
    Animator _anim;
    [Header("Audio")]
    Audiomanager _audiomanager;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
       _PlayerController = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerController>();
        _audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audiomanager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            _anim.SetTrigger("CheckT");
            _audiomanager.PlaySFX(_audiomanager._checkpoint);
            _PlayerController.CheckPointUp(_respawnpos.position);
            _anim.SetTrigger("CheckL");

        }
    }
}
