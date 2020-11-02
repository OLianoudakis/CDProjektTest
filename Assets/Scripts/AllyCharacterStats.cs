using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyCharacterStats : CharacterStats
{
    [SerializeField]
    private HealthBarUI m_HPUI;

    public delegate void AnnounceAllyDeath();
    public static event AnnounceAllyDeath AllyDead;

    public override void ApplyDamage(int damage)
    {
        m_currentHealth -= damage;
        m_HPUI.UpdateHealth(m_currentHealth);
        if (m_currentHealth <= 0)
        {
            m_currentHealth = 0;
            AllyDead?.Invoke();
            gameObject.SetActive(false);
        }
    }

    public override void ApplyHealthRecovery(int amount)
    {
        m_currentHealth += amount;
        if (m_currentHealth > m_maxHealth)
        {
            m_currentHealth = m_maxHealth;
        }
        m_HPUI.UpdateHealth(m_currentHealth);
    }

    private void Awake()
    {
        m_currentHealth = m_stats.HP;
        m_maxHealth = m_stats.HP;

        m_HPUI.SetSliderMaxValue(m_maxHealth);
    }
}
