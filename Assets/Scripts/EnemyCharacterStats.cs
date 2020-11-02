using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacterStats : CharacterStats
{
    [SerializeField]
    private HealthBarUI m_HPUI;
    [SerializeField]
    private GameObject m_ammoBox;

    private bool m_firstShot = true;

    public delegate void AnnounceFirstShot();
    public static event AnnounceFirstShot TookFirstShot;

    public delegate void AnnounceDeath();
    public static event AnnounceDeath EnemyDead;

    private void FirstShot()
    {
        m_firstShot = false;
        TookFirstShot?.Invoke();
    }

    public override void ApplyDamage(int damage)
    {
        if (m_firstShot)
        {
            FirstShot();
            return;
        }

        m_currentHealth -= damage;
        m_HPUI.UpdateHealth(m_currentHealth);
        if (m_currentHealth <= 0)
        {
            m_currentHealth = 0;
            EnemyDead?.Invoke();
            if(m_ammoBox)
            {
                GameObject ammoBox = Instantiate(m_ammoBox, transform.position, Quaternion.identity);
                ammoBox.transform.parent = null;
            }
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
