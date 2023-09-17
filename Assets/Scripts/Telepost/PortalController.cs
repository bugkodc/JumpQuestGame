using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform _destination;
    GameObject _player;
    SpriteRenderer _renderer;
    public Sprite _Opens, _Close;
    [Header("Audio")]
    Audiomanager _audiomanager;
    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _player = GameObject.FindGameObjectWithTag("player");
        _renderer.sprite = _Close;
        _audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audiomanager>();
    }
    private void Update()
    {
        if (Vector2.Distance(_player.transform.position, transform.position) < 5f)
        {
            _renderer.sprite = _Opens;
        }
        else
        {
            _renderer.sprite = _Close;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            _audiomanager.PlaySFX(_audiomanager._tele);
            if (Vector2.Distance(_player.transform.position, transform.position) > 1f)
            {
                _player.transform.position = new Vector3(_destination.transform.position.x , _destination.transform.position.y, _player.transform.position.z); 
            }
              
        }
    }
}
