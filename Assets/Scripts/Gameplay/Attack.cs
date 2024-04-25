using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack 
{
    private int _dammage;
    private ElementalType _type;
    //private FightingInstance _launcher;
    private FightingInstance _target;
    

    public Attack(int dammage, ElementalType type, /*FightingInstance launcher,*/ FightingInstance target)
    {
        this._dammage = dammage;
        this._type = type;
        //this._launcher = launcher;
        this._target = target;
    }
    public void ChangeDammage(int valueToAddOrRemove)
    {
        _dammage = Mathf.Clamp(0, _dammage + valueToAddOrRemove, 999);
    }
    public int GetDammage()
    {
        return _dammage;
    }

    public void ProcessAttack()
    {

    }
}
