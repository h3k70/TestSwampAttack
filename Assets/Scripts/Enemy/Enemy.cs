using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(EnemyStateMachine))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private Player _target;

    private Animator _animator;
    private HashAnimationCrab _animationCrab = new HashAnimationCrab();
    private EnemyStateMachine _stateMachine;
    private Collider _colider;

    public int Reward => _reward;
    public Player Target => _target;

    public event UnityAction<Enemy> Dying;

    public void Init(Player target)
    {
        _target = target;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _stateMachine = GetComponent<EnemyStateMachine>();
        _colider = GetComponent<Collider>();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if(_health <= 0)
        {
            Dying?.Invoke(this);

            _colider.enabled = false;
            _stateMachine.Stop();

            _animator.Play(_animationCrab.Die);

            float animationCrabDieLength = 2f;
            Destroy(gameObject, animationCrabDieLength);
        }
    }
}
