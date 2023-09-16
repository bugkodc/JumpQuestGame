using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OB_moving : MonoBehaviour
{
    [Range(0f, 10f)] 
    public float _speed;
    private Vector3 _tagetPos;
    [SerializeField] private GameObject _ways;
    [SerializeField] private Transform[] _waysPos;
    int _PosIndex;
    int _PosCount;
    int _direction = 1;
    [Range(0, 3)]
    public float _wait;
    int _speedMultipler = 1;
    private void Awake()
    {
        _waysPos = new Transform[_ways.transform.childCount];
        for(int i = 0; i < _ways.gameObject.transform.childCount; i++)
        {
            _waysPos[i] = _ways.transform.GetChild(i).gameObject.transform;
        }
    }
    private void Start()
    {
         _PosCount = _waysPos.Length;
        _PosIndex = 1;
        _tagetPos = _waysPos[_PosIndex].transform.position;
    }
    private void Update()
    {
        var step = _speedMultipler*_speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,_tagetPos,step);
        if(transform.position == _tagetPos)
        {
            NextPoint();
        }
    }
    void NextPoint()
    {
        if(_PosIndex == _PosCount - 1)
        {
            _direction = -1;
        }
        if(_PosIndex == 0)
        {
            _direction = 1;
        }
        _PosIndex += _direction;
        _tagetPos = _waysPos[_PosIndex].transform.position;
        StartCoroutine(waitNextPoint());
    }
   IEnumerator waitNextPoint()
    {
        _speedMultipler = 0;
        yield return new WaitForSeconds(_wait);
        _speedMultipler = 1;
    } 
}
