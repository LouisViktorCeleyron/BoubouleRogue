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

    public void SetStatus(StatusEffect status, int amount)
    {
        var statusIndex = statusDico.FindIndex((FlemmeDeDicoStatusAndUI s) => s.statusEffect == status);
        if(statusIndex>=0)
        {
            var foundedStatus = statusDico[statusIndex];
            if(amount<=0)
            {
                foundedStatus.statusUI.gameObject.SetActive(false);
            }
            else
            {
                foundedStatus.statusUI.gameObject.SetActive(true);
                foundedStatus.statusUI.SetStatus(amount);
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