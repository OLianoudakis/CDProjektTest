using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForJumpState : MonoBehaviour
{
    private JumpState m_jumpState;

    private StateMachine m_stateMachine;
    private GroundChecks m_groundChecks;
    private InputController m_inputController;

    private void Awake()
    {
        m_jumpState = transform.parent.parent.Find("States").GetComponentInChildren(typeof(JumpState)) as JumpState;

        m_stateMachine = transform.parent.parent.GetComponentInChildren(typeof(StateMachine)) as StateMachine;
        m_groundChecks = transform.parent.parent.GetComponent(typeof(GroundChecks)) as GroundChecks;
        m_inputController = transform.parent.parent.GetComponent(typeof(InputController)) as InputController;
    }

    private void Update()
    {
        if (m_inputController.JumpButtonDown && m_groundChecks.IsPlayerGrounded())
        {
            m_stateMachine.SetState(m_jumpState);
        }
    }
}