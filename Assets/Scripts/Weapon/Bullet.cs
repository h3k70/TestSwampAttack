using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _duration;

    private void Start()
    {
        StartCoroutine(Flight());
    }
    private void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);

            Destroy(gameObject);
        }
    }

    private IEnumerator Flight()
    {
        float currentTime = 0;

        while (_duration > currentTime)
        {
            currentTime += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
        yield break;
    }
}
