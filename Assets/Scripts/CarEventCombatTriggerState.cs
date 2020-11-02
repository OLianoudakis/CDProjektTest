using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEventCombatTriggerState : State
{
    [SerializeField]
    private EventsManager m_eventsManager;

    [SerializeField]
    private StateMachine m_eventStateMachine;
    [SerializeField]
    private State m_eventNextState;

    [SerializeField]
    private StateMachine m_militiaStateMachine_1;
    //[SerializeField]
    //private StateMachine m_militiaStateMachine_2;

    [SerializeField]
    private State m_militiaThreatState_1;

    public override void BeginState()
    {
        gameObject.SetActive(true);
    }

    public override void EndState()
    {
        gameObject.SetActive(false);
    }

    public void ChangeToCombat()
    {
        m_eventsManager.SwitchToCarEvent();
        //if (transform.parent.gameObject.activeSelf)
        //{
        m_eventStateMachine.SetState(m_eventNextState);
        m_militiaStateMachine_1.SetState(m_militiaThreatState_1);
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ChangeToCombat();
            //m_militiaStateMachine_2.SetState(m_militiaWarningState_2);
        }
    }
}