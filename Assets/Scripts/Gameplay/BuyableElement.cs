using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyableElement : MonoBehaviour
{

    public Element element;
    [SerializeField]
    private Image _image;
    [SerializeField]
    private Button _button;

    [SerializeField]
    private TextMeshProUGUI _priceText, _nameText;

    private PlayerManager _playerManager;


    private void Start()
    {
        SetupUI();
        _playerManager = ManagerManager.GetManager<PlayerManager>();
    }

    private void SetupUI()
    {
        _image.sprite = element.icone;
        _priceText.text = element.basePrice.ToString();
        _nameText.text = element.name;
    }

    public void BuyObject()
    {
        if(_playerManager.currentGold>= element.basePrice)
        {
            _playerManager.Deck.Add(element);
            _button.interactable = false;
        }
    }



}
