using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combinator : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer,_bgSpriteRenderer;
    public Element element;
    private bool _isSelected;


    private BattleManager _battleManager;
    private UIManager _uiManager;


    private Combinator _otherCombinator;
    // Start is called before the first frame update
    void Start()
    {
        _battleManager = ManagerManager.GetManager<BattleManager>();
        _uiManager = ManagerManager.GetManager<UIManager>();
    }

    public void Initialise(Element element)
    {
        this.element = element;
        _spriteRenderer.sprite = element.icone;
    }
    private void OnMouseDrag()
    {
        if (_uiManager.IsUIOnFront())
        {
            return;
        }
        _isSelected = true;
        var mousPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane+10);
        var newPos = Camera.main.ScreenToWorldPoint(mousPos);
        transform.position = newPos.ClampedVector3(_battleManager.board.botLeft.position,_battleManager.board.topRight.position);
    }

    private void OnMouseUp()
    {
        _isSelected = false;
        
        if(_otherCombinator)
        {
            _battleManager.PlayerTurn(this, _otherCombinator);
            _battleManager.BattlePreviewSubManager.HidePreviewPlayerCombinaison();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var tempOthComb = collision.GetComponent<Combinator>();
        if(tempOthComb == _otherCombinator)
        {
            _otherCombinator = null;
            _battleManager.BattlePreviewSubManager.HidePreviewPlayerCombinaison();
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_isSelected || _otherCombinator != null) { return;}
        _otherCombinator = collision.GetComponent<Combinator>();
        if (_otherCombinator)
        {
            _battleManager.BattlePreviewSubManager.PreviewPlayerCombinaison(this,_otherCombinator);
        }
    }
}
