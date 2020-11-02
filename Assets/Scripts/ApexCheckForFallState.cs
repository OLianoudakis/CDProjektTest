using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApexCheckForFallState : MonoBehaviour
{
    [SerializeField]
    private float m_apexReachedThreshold = 0.2f;

    private FallingState m_fallingState;

    private StateMachine m_stateMachine;
    private CharacterController m_characterController;

    private void Awake()
    {
        m_fallingState = transform.parent.parent.Find("States").gameObject.GetComponentInChildren(typeof(FallingState)) as FallingState;

        m_stateMachine = transform.parent.parent.GetComponentInChildren(typeof(StateMachine)) as StateMachine;
        m_characterController = transform.parent.parent.GetComponent(typeof(CharacterController)) as CharacterController;
    }

    private void Update()
    {
        if (Mathf.Abs(0.0f - m_characterController.velocity.y) <= m_apexReachedThreshold)
        {
            m_stateMachine.SetState(m_fallingState);
        }
    }
}