using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CseCollection 
{
    [SerializeField]
    private List<ConsequenceSpecialEffect> _collection;

    public void CallEffects(FightingInstance instanceTarget)
    {
        foreach (var cse in _collection)
        {
            cse.ApplyEffect(instanceTarget);
        }
    }
}
