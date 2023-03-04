using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CelebrationState : State
{
    private Animator _animator;
    private HashAnimationCrab _animationCrab = new HashAnimationCrab();

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play(_animationCrab.Victory);
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}
