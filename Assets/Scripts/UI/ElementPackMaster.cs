using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using LCStarterContent.Common;

public class ElementPackMaster : MonoBehaviour
{

    private PlayerManager _playerManager;
    [SerializeField]
    private TextMeshProUGUI _elementName, _elementDescription,_mixDescription, _numberInPackText;

    [SerializeField]
    private List<ElementPackUI> _elementPool,_elementInPack;

    private bool _isReady;

    //Faut vrmnt que je passe par une delegate ou une optimisation du bail
    public ElementDeletePackSubMaster elementDeletePackSubMaster;

    private void Start()
    {
        _playerManager = ManagerManager.GetManager<PlayerManager>();
        elementDeletePackSubMaster.Init();   
        _elementInPack = new List<ElementPackUI>();
        _isReady = true;
    }

    private void OnEnable()
    {
        if(!_isReady) 
        {
            Start();
        }
        AddElementsToPack();
    }

    public void AddElementsToPack()
    {
        foreach (var element in _elementPool)
        {
            element.Disable();
        }
        _elementInPack = new List<ElementPackUI>();

        foreach (var element in _playerManager.Deck)
        {
            var f = _elementInPack.FindIndex((ElementPackUI eui) => eui.Element == element);
            if (f < 0)
            {
                var e = GetAvailable();
                e.SetElement(element);
                _elementInPack.Add(e);
            }
        }
        UpdateUI(_elementInPack[0].Element);
    }

    public ElementPackUI GetAvailable()
    {
        ElementPackUI ret = null;

        foreach (var elui in _elementPool)
        {
            if(!elui.gameObject.activeInHierarchy)
            {
                elui.gameObject.SetActive(true);
                if(elementDeletePackSubMaster.use)
                {
                    Debug.Log("Oui");
                    elui.Init(this, _playerManager,elementDeletePackSubMaster.RegisterElementToDelete);
                }
                else
                {
                    elui.Init(this, _playerManager);
                }
                return elui;
            }
        }

        return ret;
    }

    public void UpdateUI(Element element) 
    { 
        _elementName.text = element.GetColoredElementName();
        _elementDescription.text = element.description;

        var mix = string.Empty;
        if(element.potentialMix.Length > 0) 
        { 
            for (int i = 0; i < element.potentialMix.Length; i++)
            {
                mix += $" - {element.potentialMix[i].GetColoredElementName()} <br>";
            }
            mix += $" - or {"itself ?".ColorizeString(element.color)} <br>";
        }

        _numberInPackText.text = $"You have {_playerManager.GetHowManyOfAnElementInDeck(element).ColorizeString(element.color)} {element.GetColoredElementName()} in your deck";

        _mixDescription.text = $"Have you try mixing {element.GetColoredElementName()} with: <br> {mix}";
    }

    public void Sure()
    {
        //Faut vrmnt que je passe par une delegate ou une optimisation du bail
        elementDeletePackSubMaster.Sure();
    }
}
