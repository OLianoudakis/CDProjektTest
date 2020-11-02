using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineCamera : MonoBehaviour
{
    protected StateCamera m_currentState;

    private StateCamera[] m_states;

    public void SetState(StateCamera state)
    {
        if (!m_currentState)
        {
            m_currentState = state;
            m_currentState.BeginState();
            return;
        }
        m_currentState.EndState();
        m_currentState = state;
        m_currentState.BeginState();
    }

    public void ResetStateValues()
    {
        for (int i = 1; i < m_states.Length; ++i)
        {
            m_states[i].ResetStateValues();
        }
    }

    private void Awake()
    {
        m_states = GetComponentsInChildren<StateCamera>();
    }

    private void Start()
    {
        for (int i = 1; i < m_states.Length; ++i)
        {
            m_states[i].gameObject.SetActive(false);
        }
        SetState(m_states[0]);
    }
}
