using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEventIntroState : State
{
    [SerializeField]
    private StateMachine m_eventStateMachine;
    [SerializeField]
    private State m_eventNextState;

    [SerializeField]
    private StateMachine m_militiaStateMachine_1;
    //[SerializeField]
    //private StateMachine m_militiaStateMachine_2;

    [SerializeField]
    private EnemyWarningState m_militiaWarningState_1;
    //[SerializeField]
    //private EnemyWarningState m_militiaWarningState_2;

    public override void BeginState()
    {
        gameObject.SetActive(true);
    }

    public override void EndState()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            m_eventStateMachine.SetState(m_eventNextState);
            m_militiaStateMachine_1.SetState(m_militiaWarningState_1);
            //m_militiaStateMachine_2.SetState(m_militiaWarningState_2);
        }
    }
}