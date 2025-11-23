using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarterPackSetUp : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _descriptionText, _nameText, _contentText;
    [SerializeField]
    private PackBridgeUI _defaultPack;
    private PlayerManager _playerManager;
    [SerializeField]
    private List<PackBridgeUI> _packs;

    void Start()
    {
        _playerManager = ManagerManager.GetManager<PlayerManager>();
        SetUpPack(_defaultPack);    
    }


    public void SetUpPack(PackBridgeUI selectedPack)
    {
        foreach (var pack in _packs)
        {
            pack.UnselectFB();
        }
        selectedPack.SelectFB();
        SetUpGameplayData(selectedPack.Pack);
        SetUpFeedback(selectedPack.Pack);
    }

    private void SetUpGameplayData(StarterPack starterPack)
    {
        _playerManager.ClearDeck();
        foreach (var element  in starterPack.elements.keys)
        {
            _playerManager.AddElementToDeck(element, starterPack.elements[element]);
        }
    }
    private void SetUpFeedback(StarterPack starterPack)
    {
        _descriptionText.text = starterPack.GetDescription();
        _nameText.text = $"{starterPack.name.ColorizeString(starterPack.color)} Pack";
        var content = string.Empty;
        foreach (var element in starterPack.elements.keys)
        {
            content +=
             $"{starterPack.elements[element]} {element.name.ColorizeString(element.color)}<br>";
        }
        _contentText.text = content;
    }

}
