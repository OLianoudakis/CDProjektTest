using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField]
    private Slider m_HPSlider;
    [SerializeField]
    private Slider m_HPSliderBGEffect;
    [SerializeField]
    private Slider m_shieldSlider;

    public void SetSliderMaxValue(int value)
    {
        m_HPSlider.maxValue = value;
        m_HPSliderBGEffect.maxValue = value;

        m_HPSlider.value = value;
        m_HPSliderBGEffect.value = value;
    }

    public void SetShieldMaxValue(int value)
    {
        m_shieldSlider.maxValue = value;
        m_shieldSlider.value = value;
    }

    public void UpdateShield(int shieldValue)
    {
        m_shieldSlider.value = shieldValue;
    }

    public void UpdateHealth(int health)
    {
        if (m_HPSlider.value > health && gameObject.activeSelf)
        {
            m_HPSlider.value = health;
            StopAllCoroutines();
            StartCoroutine(UpdateBGEffect());
        }
        else
        {
            StartCoroutine(RaiseHPEffect(health));
        }
    }

    private IEnumerator UpdateBGEffect()
    {
        yield return new WaitForSeconds(0.3f);
        float startingValue = m_HPSliderBGEffect.value;
        float step = 0.0f;
        while (m_HPSliderBGEffect.value > m_HPSlider.value)
        {
            m_HPSliderBGEffect.value = Mathf.Lerp(startingValue, m_HPSlider.value, step);
            step += 1.5f * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        m_HPSliderBGEffect.value = m_HPSlider.value;
        yield return null;
    }

    private IEnumerator RaiseHPEffect(int healthTarget)
    {
        float startingValue = m_HPSlider.value;
        float step = 0.0f;
        while (m_HPSlider.value < healthTarget)
        {
            m_HPSlider.value = Mathf.Lerp(startingValue, healthTarget, step);
            step += 0.5f * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        m_HPSlider.value = healthTarget;
        m_HPSliderBGEffect.value = m_HPSlider.value;
        yield return null;
    }
}