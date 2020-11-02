using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasStateMachine : MonoBehaviour
{
    protected State m_currentState;

    private State[] m_states;

    public void SetState(State state)
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

    public State GetCurrentState()
    {
        return m_currentState;
    }

    private void Awake()
    {
        m_states = GetComponentsInChildren<State>();
    }

    private void Start()
    {
        SetState(m_states[0]);
    }
}
