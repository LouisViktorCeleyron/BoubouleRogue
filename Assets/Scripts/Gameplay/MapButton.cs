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
    private SpriteRenderer _sprite, _bgSprite;

    [SerializeField]
    private Color _clickable, _future, _past;
    [SerializeField]
    private Color _bgUnhover,_bgHover;

    [SerializeField]
    private Animator _anim;

    public void SetUp(int floor)
    {
        if(_floor == floor)
        {
            _sprite.color = _clickable;
            _onClick.Enable();
            _anim.SetTrigger("Hovered");
        }
        if (_floor < floor)
        {
            _sprite.color = _past;
            _onClick.Disable();
        }
        if (_floor > floor)
        {
            _sprite.color = _future;
            _onClick.Disable();
        }
    }

    public void ChangeBG(bool hover)
    {
        _bgSprite.color = hover?_bgHover:_bgUnhover;
    }
}
