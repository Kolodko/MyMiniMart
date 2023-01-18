using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorController : MonoBehaviour
{
    //Анимации игрока и покупателей
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }


    public void PlayIdle()
    {
        _animator.SetTrigger("Idle");
    }

    public void PlayRun()
    {
        _animator.SetTrigger("Run");
    }
}
