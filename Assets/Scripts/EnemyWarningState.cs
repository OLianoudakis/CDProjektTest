using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWarningState : State
{
    [SerializeField]
    private TalkingNPC m_currentTalkingNPC;
    [SerializeField]
    private StateMachine m_playerStateMachine;
    [SerializeField]
    private TalkingState m_playerTalkingState;

    private NPCTalk m_npcTalk;

    public override void BeginState()
    {
        gameObject.SetActive(true);
        m_currentTalkingNPC.CurrentTalkingNPC = m_npcTalk;
        m_playerStateMachine.SetState(m_playerTalkingState);
        m_npcTalk.Interact();
    }

    public override void EndState()
    {
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        m_npcTalk = GetComponent(typeof(NPCTalk)) as NPCTalk;
    }
}