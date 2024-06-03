using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Manager
{
    public int hpMax, currentHp;
    public List<Element> Deck;
    public int currentGold;
    public override void ManagerPreAwake()
    {
        base.ManagerPreAwake();
    }
}
