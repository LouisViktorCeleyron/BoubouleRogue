using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUGGER_MAP : MonoBehaviour
{
    private PlayerManager _playerManager;
    private JourneyManager _journeyManager;
    private MySceneManager _sceneManager;

    [SerializeField]
    private GUIStyle _style;

    [SerializeField]
    private OpponentData[] _loadableOpponent;
    [SerializeField]
    private bool showDebug;
    // Start is called before the first frame update
    void Start()
    {
        _playerManager = ManagerManager.GetManager<PlayerManager>();
        _journeyManager = ManagerManager.GetManager<JourneyManager>();
        _sceneManager = ManagerManager.GetManager<MySceneManager>();
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
    private Vector2 scrollview;
    private void OnGUI()
    {
        if (showDebug)
        {
            GUILayout.BeginArea(new Rect(0, 0, Screen.width / 4f, Screen.height));
            if (GUILayout.Button("Win 10 Golds",_style))
            {
                _playerManager.AddGold(10);
            }

            scrollview = GUILayout.BeginScrollView(scrollview);
            foreach (var item in _loadableOpponent)
            {
                if (GUILayout.Button($"Battle {item}",_style))
                {
                    _journeyManager.SetSpecificOpponent(item);
                    _sceneManager.LoadBattle();
                }
            }
            GUILayout.EndScrollView();
            GUILayout.EndArea();
        }
    }
}
