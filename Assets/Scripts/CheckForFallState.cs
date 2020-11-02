using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForFallState : MonoBehaviour
{
    private FallingState m_fallingState;

    private StateMachine m_stateMachine;
    private GroundChecks m_playerGroundChecks;

    private void Awake()
    {
        m_fallingState = transform.parent.parent.Find("States").GetComponentInChildren(typeof(FallingState)) as FallingState;

        m_stateMachine = transform.parent.parent.GetComponentInChildren(typeof(StateMachine)) as StateMachine;
        m_playerGroundChecks = transform.parent.parent.GetComponent(typeof(GroundChecks)) as GroundChecks;
    }

    private void Update()
    {
        if (!m_playerGroundChecks.IsPlayerGrounded())
        {
            m_stateMachine.SetState(m_fallingState);
        }
    }
}