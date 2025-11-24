using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack 
{
    private int _damage;
    private ElementalType _type;
    //private FightingInstance _launcher;
    private FightingInstance _target, _launcher;
    

    public Attack(int damage, ElementalType type, FightingInstance launcher, FightingInstance target)
    {
        this._damage = damage;
        this._type = type;
        this._launcher = launcher;
        this._target = target;
    }
    public void ChangeDamage(int valueToAddOrRemove)
    {
        _damage = Mathf.Clamp(0, _damage + valueToAddOrRemove, 999);
    }
    public int GetDamage()
    {
        return _damage;
    }

    public FightingInstance GetLauncher()
    {
        return this._launcher;
    }

    public void ProcessAttack()
    {

    }
}
