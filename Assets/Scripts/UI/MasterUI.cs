using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterUI : MonoBehaviour
{
    public Image image;
    public Color colorA, colorB;

    public List<FlemmeDeDicoStatusAndUI> statusDico;

    public void SetFilling(float percent)
    {
        image.fillAmount = percent;
        image.color = Color.Lerp(colorB,colorA,percent);
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
    public StatusUI statusUI;
}