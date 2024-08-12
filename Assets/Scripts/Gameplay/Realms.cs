using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Realms", menuName ="MyStuffs/Realms")]
public class Realms : ScriptableObject
{
    public List<OpponentData> availableOpponents;
    public OpponentData boss;
}
