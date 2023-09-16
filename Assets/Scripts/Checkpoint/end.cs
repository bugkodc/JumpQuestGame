using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class end : MonoBehaviour
{
    PlayerController _PlayerController;
    [SerializeField] public GameObject _netxmenu;

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
            Nextlevel();
        }
    }
    public void Nextlevel()
    {
        _netxmenu.SetActive(true);
        Time.timeScale = 0;
    }
}
