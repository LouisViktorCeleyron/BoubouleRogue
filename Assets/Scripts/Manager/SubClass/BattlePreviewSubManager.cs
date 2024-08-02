using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BattlePreviewSubManager 
{
    public MyDelegate<Consequence> previewPlayerConsFB;
    public MyDelegate endPreviewFB;

    private BattleManager _battleManager;

    public void Initialize()
    {
        _battleManager = ManagerManager.GetManager<BattleManager>();

        previewPlayerConsFB = new MyDelegate<Consequence>();
        endPreviewFB = new MyDelegate();
    }


    public void PreviewPlayerCombinaison(Combinator a, Combinator b)
    {
        var c = _battleManager.book.GetConsequence(a.element, b.element);
        previewPlayerConsFB.Launch(c);
    }

    public void HidePreviewPlayerCombinaison()
    {
        endPreviewFB.Launch();
    }
}
