using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapButton : MonoBehaviour
{
    [SerializeField]
    public int _floor;
    [SerializeField]
    private OnClick _onClick;
    [SerializeField]
    private SpriteRenderer _sprite;

    [SerializeField]
    private Color _clickable, _future, _past;

    public void SetUp(int floor)
    {
        if(_floor == floor)
        {
            _sprite.color = _clickable;
            _onClick.canClick = true;
        }
        if (_floor < floor)
        {
            _sprite.color = _past;
            _onClick.canClick = false;
        }
        if (_floor > floor)
        {
            _sprite.color = _future;
            _onClick.canClick = false;
        }
    }
}
