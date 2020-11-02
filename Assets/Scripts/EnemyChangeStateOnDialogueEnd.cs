using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChangeStateOnDialogueEnd : MonoBehaviour
{
    [SerializeField]
    private StateMachine[] m_stateMachine;
    [SerializeField]
    private State[] m_nextState;

    private void OnEnable()
    {
        NPCTalk.DialogueEnding += ChangeState;
    }

    private void OnDisable()
    {
        NPCTalk.DialogueEnding -= ChangeState;
    }

    private void ChangeState()
    {
        for (int i = 0; i < m_stateMachine.Length; i++)
        {
            m_stateMachine[i].SetState(m_nextState[i]);
        }
       
    }
}