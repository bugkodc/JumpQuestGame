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
            _audiomanager.PlaySFX(_audiomanager._winner);
            Nextlevel();
        }
    }
    public void Nextlevel()
    {
        _netxmenu.SetActive(true);
        Time.timeScale = 0;
    }
}
