using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Vector2 _checkpoint;
    private Animator _anim;
    private Rigidbody2D _rigidbody;
    [Header("Audio")]
    Audiomanager _audiomanager;
    [SerializeField] public float _healplayer = 0.3f;
    [SerializeField] public GameObject _losemenu;
    [SerializeField] public Image _image;
    [SerializeField] public TextMeshProUGUI _countitemAp;
    [SerializeField] public TextMeshProUGUI _countitemBana;
    [SerializeField] public TextMeshProUGUI _countitemChere;
    public int _countAp = 0;
    public int _countBana = 0;
    public int _countChere = 0;
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
        _image.fillAmount = _healplayer;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spikes"))
        {
            _healplayer = _healplayer - 0.1f;
            if (_healplayer < 0)
            {
                _losemenu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                _image.fillAmount = _healplayer;
                Die();
                _audiomanager.PlaySFX(_audiomanager._hit);
            }
        }
        if (collision.CompareTag("itemAp"))
        {
            _countAp++;
            _countitemAp.text = "X" + _countAp;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("itemBana"))
        {
            _countBana++;
            _countitemBana.text = "X" + _countBana;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("itemChere"))
        {
            _countChere++;
            _countitemChere.text = "X" + _countChere;
            Destroy(collision.gameObject);
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
