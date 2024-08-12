using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CseCollection 
{
    [SerializeField]
    [SerializeReference]
    private List<ConsequenceSpecialEffect> _collection;
    public void CallEffects(FightingInstance instanceTarget, FightingInstance launcher)
    {
        var highPrio = new List<ConsequenceSpecialEffect>();
        var lowPrio = new List<ConsequenceSpecialEffect>();
        foreach (var cse in _collection)
        {
            if (cse.HighPriority)
            {
                highPrio.Add(cse);
            }
            else
            {
                lowPrio.Add(cse);
            }
        }
        foreach (var cse in highPrio)
        {
            cse.CallEffect(instanceTarget);
        }
        foreach (var cse in lowPrio)
        {
            cse.CallEffect(instanceTarget);
        }
    }
    
    public string GetDescription()
    {
        if(_collection == null || _collection.Count ==0)
        {
            return string.Empty;
        }
        var retP = string.Empty;
        var retL = string.Empty;
        foreach (var cse in _collection)
        {
            if(cse.HighPriority) 
            { 
                retP += cse.GetCSEDescription();
            }
            else
            {
                retL += cse.GetCSEDescription();
            }
        }
        return retP + retL;
    }

    /// <summary>
    /// Prevent NRE
    /// </summary>
    public void InitializeArray()
    {
        if(_collection == null)
        {
            _collection = new List<ConsequenceSpecialEffect>();
        }
    }

    public void AddElement(string s)
    {
        InitializeArray();
        var type = Type.GetType(s); 
        var newElement = Activator.CreateInstance(type) as ConsequenceSpecialEffect;
        _collection.Add(newElement);
    }

    public void RemoveElement(int i) 
    {
        InitializeArray();
        _collection.RemoveAt(i);
    }

    public string[] GetAvailableCSEArray(List<Type> subclassString)
    {
        //Prevent NRE
        InitializeArray();
        //Prevent Old Asset Burning new Property Drawer
        if(_collection.Count >subclassString.Count)
        {
            _collection.Clear();
        }
        //Actual code
        var ret = new string[subclassString.Count-_collection.Count];
        var i = 0;
        foreach (var subClassString in subclassString)
        {
            var isInCollection = _collection.FindIndex((ConsequenceSpecialEffect cse)=> cse.GetType()==subClassString);
            if(isInCollection == -1)
            {
                ret[i] = subClassString.ToString();

                i++;
            }
        }

        return ret;
    }
}
