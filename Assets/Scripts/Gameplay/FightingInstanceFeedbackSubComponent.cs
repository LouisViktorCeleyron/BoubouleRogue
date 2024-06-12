using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FightingInstanceFeedbackSubComponent 
{
    private FightingInstance _parent;
    [SerializeField] private Animation _vfxAnimation;

    public void PlayClip(AnimationClip clip)
    {
        _vfxAnimation.AddClip(clip, clip.name);
        _vfxAnimation.clip = clip;
        _vfxAnimation.Play();
    }

}
