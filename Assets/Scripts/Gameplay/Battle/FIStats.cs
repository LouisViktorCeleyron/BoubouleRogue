using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class FIStats
{
    private int _strength;

    public int Strength=> _strength;


    private int _bulk;

    public int Bulk => _bulk;

    [SerializeField]
    private int _hpMax = 30;
    [SerializeField]
    private int _currentHp = 30;

    private FightingInstance _parent;

    public FIStats(FightingInstance parent)
    {
        _parent = parent;
    }

    public void AddStrength(int value)
    {
        SetStrength(_strength + value);
    }

    public void SetStrength(int value)
    {
        _strength = Mathf.Clamp(value, 0, 999);
    }

    public void AddBulk(int value)
    {
        SetBulk(_bulk + value);
    }

    public void SetBulk(int value)
    {
        _bulk = Mathf.Clamp(value, -999, 999);
    }

    public int GetHp()
    {
        return _currentHp;
    }

    public void SetHp(int newAmount, bool negativeFeedback = true)
    {
        _currentHp = Mathf.Clamp(newAmount, 0, _hpMax);
        _parent.OnHpChanged.Invoke(_currentHp, _hpMax);
        _parent.SetHpMoreFeedback();
        if (_currentHp <= 0)
        {
            _parent.EndOfBattle();
        }
    }

    public void SetHpMax(int value)
    {
        _hpMax = value;
    }
    public void AddHp(int value, bool negativeFeedback = true)
    {
        SetHp(_currentHp + value, negativeFeedback );
    }


}
