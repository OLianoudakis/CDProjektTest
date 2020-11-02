using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyThreatState : State
{
    [SerializeField]
    private TalkingNPC m_currentTalkingNPC;
    [SerializeField]
    private StateMachine m_playerStateMachine;
    [SerializeField]
    private TalkingState m_playerTalkingState;
    [SerializeField]
    private Text m_mainQuest;
    [SerializeField]
    private Text m_sideQuest;

    private NPCTalk m_npcTalk;

    public override void BeginState()
    {
        gameObject.SetActive(true);
        m_mainQuest.text = "Take out the Militech";
        m_sideQuest.text = "Bonus: Interrogate the employee";
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