using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;

    private Wave _currentWave;
    private int _currentWaveNumber = -1;
    private float _timeAfterLastSpawn;
    private int _spawned;
    private int _numberOfKilled;

    public event UnityAction AllEnemyKilled;

    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Deley && _currentWave.Count > _spawned)
        {
            InstantiateEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0;
        }

        if (_currentWaveNumber + 2 <= _waves.Count)
        {
            if (_currentWave.Count <= _numberOfKilled)
            {
                _numberOfKilled = 0;
                AllEnemyKilled?.Invoke();
                _currentWave = null;
            }
        }
    }

    public void NextWave()
    {
        SetWave(++_currentWaveNumber);
        _spawned = 0;
    }

    private void InstantiateEnemy()
    {
        Enemy enemy = Instantiate(_currentWave.Template, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint).GetComponent<Enemy>();
        enemy.Init(_player);
        enemy.Dying += OnEnemyDing;
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
    }

    private void OnEnemyDing(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDing;

        _numberOfKilled++;

        _player.AddMoney(enemy.Reward);
    }
}
[System.Serializable]

public class Wave
{
    public GameObject Template;
    public float Deley;
    public int Count;
}