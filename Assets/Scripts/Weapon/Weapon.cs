using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _Label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBuyed = false;

    [SerializeField] protected Transform _shootPoint;
    [SerializeField] protected Bullet Bullet;

    public string Label => _Label;
    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsBuyed => _isBuyed;

    public abstract void Shoot();

    public void Buy()
    {
        _isBuyed = true;
    }
}
