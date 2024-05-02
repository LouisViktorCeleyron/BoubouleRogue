using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Consequence : ScriptableObject
{
    public bool selfInflicted;
    public Sprite icon;
    protected FightingInstance _target, _launcher;


    public void CallConsequence(FightingInstance launcher, FightingInstance opponent)
    {
        _target = selfInflicted ? launcher : opponent;
        $"{launcher.gameObject.name} launched {name}, {_target.name} is the target".ColorDebugLog(Color.red);
        _launcher = launcher;
        ConsequenceAction();
    }

    protected virtual void ConsequenceAction()
    {

    }
}
