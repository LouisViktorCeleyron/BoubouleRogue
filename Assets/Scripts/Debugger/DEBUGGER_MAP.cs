using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUGGER_MAP : MonoBehaviour
{
    private PlayerManager _playerManager;

    [SerializeField]
    private bool showDebug;
    // Start is called before the first frame update
    void Start()
    {
        _playerManager = ManagerManager.GetManager<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                showDebug = !showDebug;
            }
        }

    }

    private void OnGUI()
    {
        if (showDebug)
        {
            if(GUILayout.Button("Win 10 Golds"))
            {
                _playerManager.AddGold(10);
            }
        }
    }
}
