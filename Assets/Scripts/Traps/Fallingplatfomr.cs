using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallingplatfomr : MonoBehaviour
{
    [SerializeField] private Transform _posA, _posB;
    Vector3 _tagetpos;
    [SerializeField] private float _speed;
    // Start is called before the first frame update
    private void Start()
    {
        _tagetpos = _posA.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(transform.position, _posB.position) < 0.05f) _tagetpos = _posA.position;
        if (Vector2.Distance(transform.position, _posA.position) < 0.05f) _tagetpos = _posB.position;
        transform.position = Vector3.MoveTowards(transform.position,_tagetpos, _speed*Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player")) collision.transform.SetParent(this.transform);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("player")) collision.transform.SetParent(null);
    }
}
