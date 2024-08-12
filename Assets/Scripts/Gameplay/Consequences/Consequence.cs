using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Consequence : ScriptableObject
{
    public bool selfInflicted,destroyElements;
    public Sprite icon;
    public AnimationClip clip;
    protected FightingInstance _target, _launcher, _otherTarget;

    [SerializeField]
    protected CseCollection _cseCollection; 


    public void CallConsequence(FightingInstance launcher, FightingInstance opponent)
    {
        _target = selfInflicted ? launcher : opponent;
        _otherTarget = selfInflicted ? opponent : launcher;
        //$"{launcher.gameObject.name} launched {name}, {_target.name} is the target".ColorDebugLog(Color.red);
        _launcher = launcher;
        ConsequenceAction();
        _cseCollection.CallEffects(_target,_launcher);
        if(clip)
        {
            _target.feedbackSubComp.PlayClip(clip);
        }
    }

    protected string GetTargetName()
    {
        return selfInflicted ? "Self" : "Opponent";
    }

    protected virtual void ConsequenceAction()
    {

    }

    public virtual string GetDescription(FightingInstance launcher = null)
    {
        var ret = _cseCollection.GetDescription() + " To " + GetTargetName() + ". ";
        var destroyRet = destroyElements?"Remove Element from Pack Until the end of the battle. ":string.Empty;
        return destroyRet+ret;
    }

}
