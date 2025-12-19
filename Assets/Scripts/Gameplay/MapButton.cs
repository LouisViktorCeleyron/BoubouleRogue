using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Unity.VisualScripting;

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
    private Image[] _imageRef;
    [SerializeField]
    private UnityEvent _afterLine;
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

    public void LaunchActionAfterFillingPath()
    {
        StartCoroutine(SetLineFill());
    }

    private IEnumerator SetLineFill()
    {
        var fa = 0f;
        while (fa <= 1)
        {
            fa += Time.deltaTime * 2;
            foreach (var item in _imageRef)
            {
                item.fillAmount = fa;
            }
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(.5f);
        _afterLine.Invoke();
    }

    public void ChangeBG(bool hover)
    {
        _bgSprite.color = hover?_bgHover:_bgUnhover;
    }
}
