using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UpdatePackColorSelection : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    private Color _startColor, _targetColor;

    private float _speed, _time;

    private Color _colorA,_colorB;

    public void UpdateColor(PackBridgeUI _packUI)
    {
        _colorA = _packUI.colorA;
        _colorB = _packUI.colorB;

        _startColor = _colorA;
        _targetColor = _colorB;

    }

    void Update()
    {
        _time += Time.deltaTime * (_speed / 10f);
        _camera.backgroundColor = Color.Lerp(_startColor, _targetColor, _time);
        if (_time >= 1)
        {
            _startColor = _targetColor;
            _targetColor = _targetColor == _colorA? _colorB : _colorA;
            _time = 0;
        }
    }
}
