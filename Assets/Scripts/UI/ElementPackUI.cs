using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ElementPackUI : MonoBehaviour,IPointerEnterHandler
{
    [SerializeField]
    private Image _image;

    [SerializeField]
    private TextMeshProUGUI _number;

    private Element _element;
    public Element Element => _element;
    private ElementPackMaster _master;
    private PlayerManager _playerManager;

    private MyDelegate<Element> _toDoWithElement;


    public void Init(ElementPackMaster master, PlayerManager pm, UnityAction<Element> toDoWithElement = null)
    {
        _master = master;
        _playerManager = pm;
        _toDoWithElement = new MyDelegate<Element>();
        _toDoWithElement.Subscribe(toDoWithElement);
    }

    public void SetElement(Element element)
    {
        _image.sprite = element.icone;
        _element = element;
        _number.text = _playerManager.GetHowManyOfAnElementInDeck(element).ToString("00");
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _master.UpdateUI(_element);
    }

    public void OnClick()
    {
        _toDoWithElement.Launch(Element);
    }
}
