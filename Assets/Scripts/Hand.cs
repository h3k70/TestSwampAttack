using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;

    private int _currentWeaponNumber = -1;

    public void AddWeapon(Weapon weapon)
    {
        var newWeapon = Instantiate(weapon, transform);
        _weapons.Add(newWeapon);

        if (_currentWeaponNumber >= 0)
            HideWeapon(_currentWeaponNumber);

        _currentWeaponNumber = _weapons.Count - 1;
        ChangWeapon(_currentWeaponNumber);
    }

    public void TryShot()
    {
        if (_currentWeaponNumber > -1)
        {
            _weapons[_currentWeaponNumber].Shoot();
        }
    }

    public void NextWeapon()
    {
        if (_weapons.Count - 1 > _currentWeaponNumber)
        {
            HideWeapon(_currentWeaponNumber);
            _currentWeaponNumber++;
            ChangWeapon(_currentWeaponNumber);
        }
    }

    public void PreviousWeapon()
    {
        if (0 < _currentWeaponNumber)
        {
            HideWeapon(_currentWeaponNumber);
            _currentWeaponNumber--;
            ChangWeapon(_currentWeaponNumber);
        }
    }

    private void HideWeapon(int index)
    {
        _weapons[index].gameObject.SetActive(false);
    }

    private void ChangWeapon(int number)
    {
        _currentWeaponNumber = number;
        _weapons[_currentWeaponNumber].gameObject.SetActive(true);
    }
}
