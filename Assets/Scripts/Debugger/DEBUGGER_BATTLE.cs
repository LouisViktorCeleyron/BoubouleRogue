using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DEBUGGER_BATTLE : MonoBehaviour
{
    public Element[] debugDeck;
    private BattleManager manager;

    private float _buttonSize = 50;

    [SerializeField]
    private GUIStyle _style;

    [SerializeField]
    private bool showDebug;
    // Start is called before the first frame update
    void Start()
    {
        manager = ManagerManager.GetManager<BattleManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl))
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                showDebug = !showDebug;
            }
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                ManagerManager.GetManager<MySceneManager>().LoadMap();
            }
        }
    }

    private void OnGUI()
    {
        if (showDebug)
        {
            GUILayout.BeginArea(new Rect(0,0, Screen.width/4f,Screen.height));
            foreach (var item in debugDeck)
            {
                if(GUILayout.Button($"Draw {item.name}", _style, GUILayout.MinHeight(_buttonSize)))
                {
                    manager.CombinatorSubManager.DrawSpecific(item);
                }
            }

            if(GUILayout.Button("Heal",_style,GUILayout.MinHeight(_buttonSize)))
            {
                manager.playerInstance.Heal(999);
            }
            if (GUILayout.Button("Tough",_style, GUILayout.MinHeight(_buttonSize)))
            {
                manager.playerInstance.AddStatus<Tough>(1);
            }
            GUILayout.EndArea();
        }
    }
}
