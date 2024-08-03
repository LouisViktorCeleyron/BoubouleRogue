using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimationsStuffs : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private bool _positive;
    void Start()
    {
        _animator.SetBool("Positive", _positive);
    }
}
