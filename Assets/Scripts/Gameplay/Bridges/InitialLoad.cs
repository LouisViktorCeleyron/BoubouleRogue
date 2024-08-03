using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialLoad : MonoBehaviour
{
    private MySceneManager _mySceneManager;
    // Start is called before the first frame update
    void Start()
    {
        _mySceneManager = ManagerManager.GetManager<MySceneManager>();
        _mySceneManager.LoadMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
