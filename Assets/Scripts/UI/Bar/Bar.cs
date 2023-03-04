using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Slider Slider;
    [SerializeField] protected float Duration = 100;

    protected Coroutine ChangingValueJob;
    protected float RunningTime;
    protected float ScalePercentage;

    public void OnValueChanged(int value, int maxValue)
    {
        if (ChangingValueJob != null)
            StopCoroutine(ChangingValueJob);

        ScalePercentage = (float)value / maxValue;
        ChangingValueJob = StartCoroutine(ChangingValue(ScalePercentage));
    }

    private IEnumerator ChangingValue(float targetValue)
    {
        RunningTime = 0;

        while (Slider.value != targetValue)
        {
            RunningTime += Time.deltaTime;
            Slider.value = Mathf.MoveTowards(Slider.value, targetValue, RunningTime / Duration);

            yield return null;
        }
    }
}
