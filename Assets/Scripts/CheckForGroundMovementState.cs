using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForGroundMovementState : StateChange
{
    private GroundMovementState m_groundMovementState;

    private StateMachine m_stateMachine;
    private GroundChecks m_groundChecks;
    private CharacterController m_characterController;

    private void Awake()
    {
        m_groundMovementState = transform.parent.parent.Find("States").GetComponentInChildren(typeof(GroundMovementState)) as GroundMovementState;

        m_stateMachine = transform.parent.parent.GetComponentInChildren(typeof(StateMachine)) as StateMachine;
        m_groundChecks = transform.parent.parent.GetComponent(typeof(GroundChecks)) as GroundChecks;
        m_characterController = transform.parent.parent.GetComponent(typeof(CharacterController)) as CharacterController;
    }

    private void Update()
    {
        if (m_groundChecks.IsPlayerGrounded() && m_groundChecks.GroundAngle <= m_characterController.slopeLimit)
        {
            m_stateMachine.SetState(m_groundMovementState);
        }
    }
}