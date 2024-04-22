using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
            manager.ManagerAwake();
        }
    }
}
