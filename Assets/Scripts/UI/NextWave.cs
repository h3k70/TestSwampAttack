using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextWave : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _nextWaveButton;
    [SerializeField] private Image _menu;

    public void OnAllEnemyKilled()
    {
        _menu.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        _nextWaveButton.onClick.AddListener(OnNextWaveButtonClick);
        _spawner.AllEnemyKilled += OnAllEnemyKilled;
    }

    private void OnDisable()
    {
        _nextWaveButton.onClick.RemoveListener(OnNextWaveButtonClick);
        _spawner.AllEnemyKilled -= OnAllEnemyKilled;
    }

    public void OnNextWaveButtonClick()
    {
        _spawner.NextWave();
        _menu.gameObject.SetActive(false);
    }
}
