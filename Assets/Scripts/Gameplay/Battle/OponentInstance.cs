using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OponentInstance : FightingInstance
{
    private OpponentData _oponentData;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private TextMeshProUGUI _opponentName;
    [SerializeField]
    private GameObject _attackPreview;
    [SerializeField]
    private TextMeshProUGUI _consNameText,_consDescText;
    private Consequence _nextConsequence;

    public void Start()
    {
        _battleManager.opponentInstance = this;
    }
    public void Initialise(OpponentData oponentData)
    {
        //Debug.Log("coucou");
        _oponentData = oponentData;
        _spriteRenderer.sprite = _oponentData.sprite;
        _opponentName.text = oponentData.name;
        _hpMax = oponentData.baseHp;
        SetHp(_hpMax);

    }
    public void SetConsequence()
    {
        _nextConsequence = _oponentData.GetRandomConsequence();
        _consDescText.text = _nextConsequence.GetDescription();
        _consNameText.text = _nextConsequence.name;
    }
    public void LaunchConsequence(BattleManager battleManager)
    {
        _nextConsequence.CallConsequence(battleManager.opponentInstance, battleManager.playerInstance);
    }

    private void OnMouseEnter()
    {
        _attackPreview.SetActive(true);
    }
    private void OnMouseExit()
    {
        _attackPreview.SetActive(false);
    }

    public override void EndOfBattle()
    {
        _battleManager.EndOfBattle(false);
    }
}
