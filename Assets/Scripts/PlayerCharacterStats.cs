using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterStats : CharacterStats
{
    [SerializeField]
    private HealthBarUI m_HPUI;
    [SerializeField]
    private StateMachine m_stateMachine;
    [SerializeField]
    private State m_nextState;
    public override void ApplyDamage(int damage)
    {
        if (m_currentShield - damage < 0 && m_currentShield != 0)
        {
            int damageLeftovers = damage - m_currentShield;
            m_currentShield = 0;
            m_HPUI.UpdateShield(m_currentShield);
            ApplyDamage(damageLeftovers);
        }
        else if (m_currentShield - damage >= 0)
        {
            m_currentShield -= damage;
            m_HPUI.UpdateShield(m_currentShield);
            return;
        }
        else
        {
            m_currentHealth -= damage;
            m_HPUI.UpdateHealth(m_currentHealth);
            if (m_currentHealth <= 0)
            {
                m_currentHealth = 0;
                m_stateMachine.SetState(m_nextState);
            }
        }
    }

    public override void ApplyShieldRecovery(int amount)
    {
        m_currentShield += amount;
        if (m_currentShield > m_maxShield)
        {
            m_currentShield = m_maxShield;
        }
        m_HPUI.UpdateShield(m_currentShield);
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

        m_currentShield = m_stats.Shield;
        m_maxShield = m_stats.Shield;

        m_HPUI.SetSliderMaxValue(m_maxHealth);
        m_HPUI.SetShieldMaxValue(m_maxShield);
    }
}
