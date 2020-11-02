using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterStats : MonoBehaviour
{
    [SerializeField]
    protected Stats m_stats;

    protected int m_currentHealth;
    protected int m_maxHealth;

    protected int m_currentShield;
    protected int m_maxShield;

    public virtual void ApplyDamage(int damage)
    {

    }

    public virtual void  ApplyShieldRecovery(int amount)
    {

    }

    public virtual void ApplyHealthRecovery(int amount)
    {

    }

    public int GetHealth()
    {
        return m_currentHealth;
    }
}
