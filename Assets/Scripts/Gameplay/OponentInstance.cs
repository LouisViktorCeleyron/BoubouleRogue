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

    public void Start()
    {
        _battleManager.opponentInstance = this;
    }
    public void Initialise(OpponentData oponentData)
    {
        _oponentData = oponentData;
        _spriteRenderer.sprite = _oponentData.sprite;
        _opponentName.text = oponentData.name;
        hpMax = oponentData.baseHp;
        SetHp(hpMax);

    }

    public void LaunchConsequence(BattleManager battleManager)
    {
        var consequence = _oponentData.GetRandomConsequence();
        consequence.CallConsequence(battleManager.opponentInstance, battleManager.playerInstance);
    }
}
