using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class LoadingSubManager 
{
    private MySceneManager _master;

    [SerializeField]
    private float _timeToTransition;
    [SerializeField]
    private Image _battleTransitionImage;

    private Image _currentImageTransition;

    public void Initialize(MySceneManager master)
    {
        _master = master;
    }

    public void BattleTranstion(UnityAction toDo)
    {
        _currentImageTransition = _battleTransitionImage;
        _master.StartCoroutine(SetOnTransition(toDo));
    }

    public void OffTransition()
    {
        if (_currentImageTransition == null)
        {
            return;
        }
        _master.StartCoroutine(SetOffTransition());
    }

    private IEnumerator SetOnTransition(UnityAction toDo)
    {
        //SuperTemp A voir si j'ai besoin de créer un master Coroutine/Gerrer le temps avec des update
        var transitionMaterial = _currentImageTransition.material;
        _currentImageTransition.gameObject.SetActive(true);
        var cutoff = 0f;

        while (cutoff <= 1)
        {
            cutoff += 0.01f;
            transitionMaterial.SetFloat("_Cutoff",cutoff);
            yield return new WaitForSeconds(_timeToTransition/100);
        }

        toDo.Invoke();

        yield return null;
    }


    private IEnumerator SetOffTransition()
    {
        //SuperTemp A voir si j'ai besoin de créer un master Coroutine/Gerrer le temps avec des update

        

        var transitionMaterial = _currentImageTransition.material;
        var cutoff = 1f;

        while (cutoff >= 0)
        {
            cutoff -= 0.01f;
            transitionMaterial.SetFloat("_Cutoff", cutoff);
            yield return new WaitForSeconds(_timeToTransition/100);
        }

        _currentImageTransition.gameObject.SetActive(false);
        yield return null;
    }

}
