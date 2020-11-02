using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStateBasedOnHealth : MonoBehaviour
{
    [SerializeField]
    private CharacterStats m_stats;
    [SerializeField]
    private StateMachine m_stateMachine;
    [SerializeField]
    private State m_nextState;
    [SerializeField]
    [Range(1, 100)]
    private int m_percentage;

    private bool flag = false;

    private bool m_percentageReached = false;
    private int m_healthNeededToBeReached;

    private void Start()
    {
        m_healthNeededToBeReached = (int)(m_stats.GetHealth() * (0.01f * m_percentage));
    }

    private void Update()
    {
        if (!m_percentageReached && m_stats.GetHealth() < m_healthNeededToBeReached && !flag)
        {
            flag = true;
            m_stateMachine.SetState(m_nextState);
        }
    }
}
