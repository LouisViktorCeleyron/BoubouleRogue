using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Oponent", menuName = "MyStuffs/Oponent")]
public class OpponentData : ScriptableObject
{
    public int baseHp;
    public List<Consequence> availableConsequences;
    public GameObject opponentPrefab;
    public Sprite sprite;
    public int baseStrengh, baseBulk;

    public List<StatusInflicted> startingStatus;

    public Consequence GetRandomConsequence()
    {
        return availableConsequences[Random.Range(0, availableConsequences.Count)];
    }
}
