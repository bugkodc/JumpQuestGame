using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 _checkpoint;
    private Animator _anim;
    private Rigidbody2D _rigidbody;
    [Header("Audio")]
    Audiomanager _audiomanager;
    // Start is called before the first frame update
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audiomanager>();
    }
    void Start()
    {
        _checkpoint = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spikes"))
        {
            Die();
            _audiomanager.PlaySFX(_audiomanager._hit);
        }

    }
    #region update_checkpoint.
    public void CheckPointUp(Vector2 _pos)
    {
        _checkpoint = _pos;
    }
    #endregion
    #region die
    void Die()
    {
        _anim.SetTrigger("hit");
        StartCoroutine(Respawns(0.5f));
    }
    #endregion
    #region respawns
    IEnumerator Respawns(float duration)
    {
        _rigidbody.simulated = false;
        _rigidbody.velocity = new Vector2(0, 0);
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(duration);
        transform.position = _checkpoint;
        transform.localScale = new Vector3(1, 1, 1);
        _rigidbody.simulated = true;
    }
    #endregion
}
