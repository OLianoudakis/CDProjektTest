using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerTalkingCollider : MonoBehaviour
{
    [SerializeField]
    private TalkingNPC m_currentTalkingNPC;
    [SerializeField]
    private StateMachine m_playerStateMachine;
    [SerializeField]
    private TalkingState m_playerTalkingState;
    [SerializeField]
    private NPCTalk m_npcTalk;
    [SerializeField]
    private Text m_mainQuest;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            m_currentTalkingNPC.CurrentTalkingNPC = m_npcTalk;
            m_playerStateMachine.SetState(m_playerTalkingState);
            m_mainQuest.text = "Learn more about the strangers";
            m_npcTalk.Interact();
            gameObject.SetActive(false);
        }
    }
}