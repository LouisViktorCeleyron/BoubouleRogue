using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyableElement : MonoBehaviour
{
    [SerializeField]
    private Element _element;
    [SerializeField]
    private Image _image;
    [SerializeField]
    private Button _button;

    [SerializeField]
    private TextMeshProUGUI _priceText, _nameText;

    private PlayerManager _playerManager;


    private void Start()
    {
        _playerManager = ManagerManager.GetManager<PlayerManager>();
    }

    public void SetupUI(Element e)
    {
        _element = e;
        _image.sprite = _element.icone;
        _priceText.text = _element.basePrice.ToString();
        _nameText.text = _element.name;
    }

    public void BuyObject()
    {
        if(_playerManager.CurrentGold>= _element.basePrice)
        {
            _playerManager.AddElementToDeck(_element);
            _button.interactable = false;
            _playerManager.AddGold(-_element.basePrice);
            _button.gameObject.SetActive(false);
        }
    }



}
