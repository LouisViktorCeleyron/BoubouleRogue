using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Consequence : ScriptableObject
{
    public bool selfInflicted;
    public Sprite icon;
    public AnimationClip clip;
    protected FightingInstance _target, _launcher;

    protected CseCollection _cseCollection; 


    public void CallConsequence(FightingInstance launcher, FightingInstance opponent)
    {
        _target = selfInflicted ? launcher : opponent;
        $"{launcher.gameObject.name} launched {name}, {_target.name} is the target".ColorDebugLog(Color.red);
        _launcher = launcher;
        ConsequenceAction();
        if(clip)
        {
            _target.feedbackSubComp.PlayClip(clip);
        }
    }

    protected virtual void ConsequenceAction()
    {

    }
}
