using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private float _lastAttacTime;
    private Animator _animator;
    private HashAnimationCrab _animationCrab = new HashAnimationCrab();

    private void Start()
    {
        _animator= GetComponent<Animator>();
    }

    private void Update()
    {
        if(_lastAttacTime <= 0)
        {
            Attack(Target);
            _lastAttacTime = _delay;
        }
        _lastAttacTime -= Time.deltaTime;
    }

    private void Attack(Player target)
    {
        _animator.Play(_animationCrab.Attack1);
        StartCoroutine(CauseDamage());
    }

    private IEnumerator CauseDamage()
    {
        var wait = new WaitForSeconds(_animator.GetCurrentAnimatorClipInfo(0).Length * 0.5f);

        yield return wait;

        if (Target != null)
        {
            Target.ApplyDamage(_damage);
        }
        yield break;
    }
}
