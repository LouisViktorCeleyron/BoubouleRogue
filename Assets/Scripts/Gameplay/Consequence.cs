using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Consequence : ScriptableObject
{
    public bool selfInflicted;
    public Sprite icon;
    protected FightingInstance _target;


    public void CallConsequence(FightingInstance launcher, FightingInstance opponent)
    {
        _target = selfInflicted ? launcher : opponent;
        ConsequenceAction();

        Debug.Log($"{launcher} à lancé {name} face à {opponent}, {_target} est la cible");
    }

    protected virtual void ConsequenceAction()
    {

    }
}
