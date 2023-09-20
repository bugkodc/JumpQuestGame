using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image _imagehealth;
    PlayerController _player;
    private void Start()
    {
        _imagehealth = GetComponent<Image>();
        _player = GetComponent<PlayerController>();
    }
    private void Update()
    {
        _imagehealth.fillAmount = _player._healplayer;
    }
}
