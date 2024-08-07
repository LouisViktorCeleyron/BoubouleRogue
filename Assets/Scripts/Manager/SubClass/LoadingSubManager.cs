using LCStarterContent.Common;
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
    private Image _shaderedTransitionImage;

    private Image _currentImageTransition;

    [SerializeField]
    private Sprite[] _battleTransitionSprites;
    [SerializeField]
    private Sprite _menuTransitionSprites;
    private Coroutine _offTransition;
    public void Initialize(MySceneManager master)
    {
        _master = master;
    }

    public void BattleTranstion(UnityAction toDo)
    {
        _currentImageTransition = _shaderedTransitionImage;
        _currentImageTransition.sprite = _battleTransitionSprites.GetRandomElement();
        _master.StartCoroutine(SetOnTransition(toDo));
    }

    public void MenuTranstion(UnityAction toDo)
    {
        _master.StopAllCoroutines();
        _currentImageTransition = _shaderedTransitionImage;
        _currentImageTransition.sprite = _menuTransitionSprites;
        _master.StartCoroutine(SetOnTransition(toDo));
    }

    public void OffTransition()
    {
        if (_currentImageTransition == null)
        {
            return;
        }
        _offTransition = _master.StartCoroutine(SetOffTransition());
    }

    private IEnumerator SetOnTransition(UnityAction toDo)
    {
        //SuperTemp A voir si j'ai besoin de créer un master Coroutine/Gerrer le temps avec des update
        if(_offTransition != null)
        {
            _master.StopCoroutine(_offTransition);
        }
        var transitionMaterial = _currentImageTransition.material;
        _currentImageTransition.gameObject.SetActive(true);
        var cutoff = 0f;
        transitionMaterial.SetFloat("_Cutoff", cutoff);

        while (cutoff <= 1)
        {
            cutoff += 0.01f;
            transitionMaterial.SetFloat("_Cutoff",cutoff);
            yield return new WaitForSeconds(_timeToTransition/100); // A Stocker pour gagner du temps
        }


        toDo.Invoke();
    }


    private IEnumerator SetOffTransition()
    {
        //SuperTemp A voir si j'ai besoin de créer un master Coroutine/Gerrer le temps avec des update


        var transitionMaterial = _currentImageTransition.material;
        var cutoff = 1f;
        
        yield return new WaitForSeconds(1.5f);

        while (cutoff >= 0)
        {
            cutoff -= 0.01f;
            transitionMaterial.SetFloat("_Cutoff", cutoff);
            yield return new WaitForSeconds(_timeToTransition/100);
        }

        _currentImageTransition.gameObject.SetActive(false);

    }

}
