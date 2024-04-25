using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combinator : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    public Element element;
    private bool _isSelected;

    private BattleManager _battleManager;   
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer.sprite = element.icone;
        _battleManager = ManagerManager.GetManager<BattleManager>();
    }

    private void OnMouseDrag()
    {
        _isSelected = true;
        var mousPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane+10);
        var newPos = Camera.main.ScreenToWorldPoint(mousPos);
        transform.position = newPos;
    }

    private void OnMouseUp()
    {
        _isSelected = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_isSelected) { return;}
        var other = collision.GetComponent<Combinator>();
        if (other)
        {
            _battleManager.PlayerTurn(element, other.element);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
