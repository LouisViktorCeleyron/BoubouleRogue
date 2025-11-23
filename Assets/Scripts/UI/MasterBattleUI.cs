using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MasterBattleUI : MonoBehaviour
{
    public Image _colorimage, _fillImage;
    public Color colorA, colorB;

    public List<FlemmeDeDicoStatusAndUI> statusDico;
    [SerializeField]
    private TextMeshProUGUI _hpText;

    [SerializeField]
    private TextMeshProUGUI _descText;
    [SerializeField]
    private GameObject _descriptionContainer;

    public void UpdateUIHP(int hp, int hpMax)
    {
        SetFilling((float)hp/(float)hpMax);
        _hpText.text = $"{hp}/{hpMax}";

    }

    private void SetFilling(float percent)
    {
        _fillImage.fillAmount = 1-percent;
        _colorimage.color = Color.Lerp(colorB,colorA,percent);
    }

    public void SetDescription(Status status)
    {
        _descriptionContainer.SetActive(true);
        _descText.text = status.GetDescription();
    }

    public void HideDescription()
    {
        _descriptionContainer.SetActive(false);
    }

    public void SetStatus(Status status)
    {
        var statusIndex = statusDico.FindIndex((FlemmeDeDicoStatusAndUI s) => s.statusEffect == status.StatusEnum);
        if(statusIndex>=0)
        {
            var foundedStatus = statusDico[statusIndex];
            if(status.Amount<=0)
            {
                foundedStatus.statusUI.gameObject.SetActive(false);
            }
            else
            {
                foundedStatus.statusUI.gameObject.SetActive(true);
                foundedStatus.statusUI.SetStatus(status,this);
            }
        }
    }
}


[System.Serializable]
public struct FlemmeDeDicoStatusAndUI
{
    public StatusEffect statusEffect;
    public StatusInBattleUI statusUI;
}