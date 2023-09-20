using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class end : MonoBehaviour
{
    PlayerController _PlayerController;
    [SerializeField] public GameObject _netxmenu;

    Animator _anim;
    [Header("Audio")]
    Audiomanager _audiomanager;
    [SerializeField] private int _countAP;
    [SerializeField] private int _countBaNa;
    [SerializeField] private int _countCheRe;
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
            if (_PlayerController._countAp == _countAP && _PlayerController._countBana == _countBaNa && _PlayerController._countChere == _countCheRe)
            {
                _audiomanager.PlaySFX(_audiomanager._winner);
                Nextlevel();
            }
        }
    }
    public void Nextlevel()
    {
        _netxmenu.SetActive(true);
        Time.timeScale = 0;
    }
}
