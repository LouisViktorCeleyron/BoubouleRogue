using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Manager : MonoBehaviour
{
    public virtual void ManagerPreAwake()
    {

    }

    public virtual void ManagerOnEachSceneStart(Scene scene)
    {

    }
}
