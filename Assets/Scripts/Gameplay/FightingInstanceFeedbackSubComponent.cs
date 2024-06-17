using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FightingInstanceFeedbackSubComponent 
{
    private FightingInstance _parent;
    public Animator vfxAnimator;

    public void PlayClip(AnimationClip clip)
    {
        vfxAnimator.Play(clip.name);
    }

}
