using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Hand _hand;

    private int _currentHealth;
    private Animator _animator;

    public int Money { get; private set; }

    public UnityAction<int, int> HealthChanged;
    public UnityAction<int> MoneyChanged;

    private void Start()
    {
        _currentHealth = _health;
        _animator= GetComponent<Animator>();
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;

        HealthChanged?.Invoke(_currentHealth, _health);

        if(_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddMoney(int money)
    {
        Money += money;

        MoneyChanged?.Invoke(Money);
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        MoneyChanged?.Invoke(Money);

        _hand.AddWeapon(weapon);
    }
}
