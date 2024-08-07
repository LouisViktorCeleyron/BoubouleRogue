using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerManager : MonoBehaviour
{
    private static ManagerManager instance;
    private List<Manager> managers;

    public void Awake()
    {
        if(ManagerManager.instance == null)
        {
            ManagerManager.instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        managers = new List<Manager>();
        managers = GetComponents<Manager>().ToList();

        ProcessManagerAwake();
        SceneManager.sceneLoaded += OnStartScene;

        DontDestroyOnLoad(gameObject);
    }


    public static T GetManager<T>() where T : Manager
    {
        foreach (var manager in instance.managers) 
        { 
            if(manager.GetType() == typeof(T))
            {
                return (T)manager;
            }
        }
        return null;
    }


    private void ProcessManagerAwake()
    {
        foreach (var manager in managers) 
        { 
            manager.ManagerPreAwake();
        }
        foreach (var manager in managers)
        {
            manager.ManagerPostAwake();
        }
    }

    public void OnStartScene(Scene newScene, LoadSceneMode loadSceneMode)
    {
        foreach (var manager in managers)
        {
            manager.ManagerOnEachSceneStart(newScene);
        }
    }

    public static void OnEndScene()
    {
        instance.OnEndScene(SceneManager.GetActiveScene());
    }
    public void OnEndScene(Scene leftScene)
    {
        foreach (var manager in managers)
        {
            manager.ManagerOnEachSceneLeft(leftScene);
        }
    }
}
