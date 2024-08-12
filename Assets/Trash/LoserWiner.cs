using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoserWiner : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI m_TextMeshProUGUI;
    // Start is called before the first frame update
    void Start()
    {
        var jm = ManagerManager.GetManager<JourneyManager>();
        if(jm.TEMP_winer)
        {
            m_TextMeshProUGUI.text = "Winner";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
