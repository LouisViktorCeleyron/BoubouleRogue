using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BatlleManagerBridge : MonoBehaviour
{
    private BattleManager _battleManager;
    [SerializeField]
    private TextMeshProUGUI _consDescriptionText, _consTitleText;

    private void Start()
    {
        _battleManager =  ManagerManager.GetManager<BattleManager>();

        _battleManager.BattlePreviewSubManager.endPreviewFB.Subscribe(StopPreview);
        _battleManager.BattlePreviewSubManager.previewPlayerConsFB.Subscribe(PreviewConsequence);

    }


    public void PreviewConsequence(Consequence consequence)
    {
        _consDescriptionText.gameObject.SetActive(true);
        _consTitleText.gameObject.SetActive(true);

        _consDescriptionText.text = consequence.GetDescription();
        _consTitleText.text = consequence.name;
    }

    public void StopPreview()
    {
        _consDescriptionText.gameObject.SetActive(false);
        _consTitleText.gameObject.SetActive(false);
    }

}
