using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GatchaButton : MonoBehaviour
{
    //Temp a faire evoluer si il y a des gatcha plus complexes
    public GatchaMaster _master;

    [SerializeField]
    private GameObject _okContainer;
    [SerializeField]
    private TextMeshProUGUI _commonText, _rareText, _legendaryText;
    [SerializeField]
    private Image _commonIcon, _rareIcon, _legendaryIcon, _resultIcon;


    private WeightedList<Element> _procableElement;
    private PlayerManager _playerManager;

    private GameObject _gatchaButtonLauncher;

    public void Init(GameObject gbl = null)
    {
        _playerManager = ManagerManager.GetManager<PlayerManager>();

        _procableElement = _master.GetElementsForGatcha();
        _gatchaButtonLauncher = gbl;

        _commonIcon.sprite = _procableElement[0].icone;
        _commonText.text = $"{_procableElement.GetWeightAtIndex(0)*10}% of {_procableElement[0].GetColoredElementName()}";
        _rareIcon.sprite = _procableElement[1].icone;
        _rareText.text = $"{_procableElement.GetWeightAtIndex(1)*10}% of {_procableElement[1].GetColoredElementName()}";
        _legendaryIcon.sprite = _procableElement[2].icone;
        _legendaryText.text = $"{_procableElement.GetWeightAtIndex(2)*10}% of {_procableElement[2].GetColoredElementName()}";
    }

    public void OnClick()
    {
        var e = _procableElement.GetRandomElement();
        _playerManager.AddElementToDeck(e);
        _okContainer.SetActive(true);
        _resultIcon.sprite = e.icone;
        _gatchaButtonLauncher?.SetActive(false);
    }
}
