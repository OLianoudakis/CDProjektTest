using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingNPC : MonoBehaviour
{
    public NPCTalk CurrentTalkingNPC
    {
        get { return m_currentTalkingNPC; }
        set { m_currentTalkingNPC = value; }
    }
    private NPCTalk m_currentTalkingNPC;
}