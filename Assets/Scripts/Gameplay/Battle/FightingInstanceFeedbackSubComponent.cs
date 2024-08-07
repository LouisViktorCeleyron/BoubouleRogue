using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class FightingInstanceFeedbackSubComponent 
{
    private FightingInstance _parent;
    public Animator vfxAnimator;
    
    public void Init(FightingInstance parent)
    {
        _parent = parent;
    }

    public void PlayClip(AnimationClip clip)
    {
        vfxAnimator.Play(clip.name);
    }

}
