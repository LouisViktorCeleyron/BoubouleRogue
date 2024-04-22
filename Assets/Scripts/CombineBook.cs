using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="CombineBook", menuName ="MyStuffs/Book")]
public class CombineBook : ScriptableObject
{
    [SerializeField]
    private List<CombinaisonWithResult> _combinaisons;
    [SerializeField]
    private Consequence _defaultConsequence;
    public Consequence GetConsequence (Element A, Element B)
    {
        var retParent = _combinaisons.Find((CombinaisonWithResult combo) => combo.elements.CheckElements(A, B));
        return retParent != null ?retParent.consequence:_defaultConsequence;
    }
}
[System.Serializable]
public struct CombinaisonElements
{
    [SerializeField]
    private Element a, b;

    public bool CheckElements(Element A, Element B)
    {
        var resA = a == A && b == B;
        var resB = a == B && b == A;
        return resA || resB;
    }

}

[System.Serializable]
public class CombinaisonWithResult
{
    public string name;
    public CombinaisonElements elements;
    public Consequence consequence;
}