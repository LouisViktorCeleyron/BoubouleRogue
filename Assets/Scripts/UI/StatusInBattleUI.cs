using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


public class StatusInBattleUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image statusImage;
    public TextMeshProUGUI textMeshProUGUI;
    private Status _linkedStatus;
    private MasterBattleUI _masterBattleUI;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(_masterBattleUI);
        _masterBattleUI.SetDescription(_linkedStatus);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _masterBattleUI.HideDescription();
    }


    // Start is called before the first frame update
    public void SetStatus(Status status, MasterBattleUI mbu)
    {
        _linkedStatus = status;
        _masterBattleUI = mbu;
        textMeshProUGUI.text = _linkedStatus.Amount.ToString();
    }


}
