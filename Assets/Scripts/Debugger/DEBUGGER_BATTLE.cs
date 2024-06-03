using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUGGER_BATTLE : MonoBehaviour
{
    public Element[] debugDeck;
    private BattleManager manager;

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
        if(showDebug)
        {
            foreach (var item in debugDeck)
            {
                if(GUILayout.Button($"Draw {item.name}"))
                {
                    manager.CombinatorSubManager.DrawSpecific(item);
                }
            }
        }
    }
}
