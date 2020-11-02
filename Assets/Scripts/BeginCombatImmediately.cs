using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginCombatImmediately : MonoBehaviour
{
    [SerializeField]
    private StateMachine m_stateMachine;
    [SerializeField]
    private CarEventCombatTriggerState m_combatState;

    private void Start()
    {
        EnemyCharacterStats.TookFirstShot += BeginCombat;
    }

    private void OnDisable()
    {
        EnemyCharacterStats.TookFirstShot -= BeginCombat;
    }

    private void BeginCombat()
    {
        m_stateMachine.SetState(m_combatState);
        m_combatState.ChangeToCombat();
    }
}
