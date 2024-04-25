using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class StatusUI : MonoBehaviour
{
    public Image statusImage;
    public TextMeshProUGUI textMeshProUGUI;
    // Start is called before the first frame update
    public void SetStatus(int amount)
    {
        textMeshProUGUI.text = amount.ToString();
    }
}
