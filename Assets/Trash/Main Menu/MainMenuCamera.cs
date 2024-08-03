using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private float
        _minColorTreshold = .5f,
        _maxColorTreshold = 1f,
        _speed =5f;
    private float _time;
    private Color _startColor, _targetColor;


    private void Start()
    {
        _startColor = GetColorInTreshold();
        _targetColor = GetColorInTreshold();
    }

    private void Update()
    {
        _time += Time.deltaTime*(_speed/10f);
        _camera.backgroundColor = Color.Lerp(_startColor, _targetColor, _time);
        if( _time >=1)
        {
            _startColor = _targetColor;
            _targetColor = GetColorInTreshold();
            _time = 0;
        }
    }

    

    private Color GetColorInTreshold()
    {
        var r = Random.Range(_minColorTreshold, _maxColorTreshold);
        var g = Random.Range(_minColorTreshold, _maxColorTreshold);
        var b = Random.Range(_minColorTreshold, _maxColorTreshold);
        return new Color(r,g,b);
    }
}
