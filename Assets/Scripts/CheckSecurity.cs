using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSecurity : MonoBehaviour
{
    [SerializeField]
    private int m_securityNumber = 0;

    private ChangeStateBasedOnHealth m_changeStateBasedOnHealth;

    public void SecurityReinforcements(int number)
    {
        m_securityNumber += number;
        m_changeStateBasedOnHealth.enabled = false;
    }

    private void OnEnable()
    {
        EnemyCharacterStats.EnemyDead += UpdateSecurityNumbers;
    }

    private void OnDisable()
    {
        EnemyCharacterStats.EnemyDead -= UpdateSecurityNumbers;
    }

    private void UpdateSecurityNumbers()
    {
        m_securityNumber--;
        if (m_securityNumber <= 0)
        {
            m_securityNumber = 0;
            SecurityIsDead();
        }
    }

    private void SecurityIsDead()
    {
        m_changeStateBasedOnHealth.enabled = true;
    }

    private void Awake()
    {
        m_changeStateBasedOnHealth = GetComponent(typeof(ChangeStateBasedOnHealth)) as ChangeStateBasedOnHealth;
    }

    private void Start()
    {
        m_changeStateBasedOnHealth.enabled = false;
    }
}
