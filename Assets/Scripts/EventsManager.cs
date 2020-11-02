using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public bool SecretEventUnlocked
    {
        set { m_secretEventUnlocked = value; }
    }
    private bool m_secretEventUnlocked = false;

    public bool FinalSpeecUnlocked
    {
        set { m_finalSpeechUnlocked = value; }
    }
    private bool m_finalSpeechUnlocked = true;

    [Header("Intro Event Attributes")]
    [SerializeField]
    private InteractDoor[] m_introDoorsAnimators;
    [SerializeField]
    private GameObject m_TalkingNCPs;

    [Space(10)]

    [Header("Car Event Attributes")]
    [SerializeField]
    private GameObject m_carEventConditionsHandler;

    [Space(10)]

    [Header("Final Event Attributes")]
    [SerializeField]
    private GameObject m_finalEvent;
    [SerializeField]
    private GameObject m_alliesGO;

    public void SwitchToCarEvent()
    {
        //Disable from Intro Event
        for(int i = 0; i < m_introDoorsAnimators.Length; i++)
        {
            m_introDoorsAnimators[i].CloseDoor();
        }
        m_TalkingNCPs.SetActive(false);

        //Enable for Car Event
        NPCTalk.DialogueEnding += EnableCarEventConditions;
    }
    public void SwitchToFinalEvent()
    {
        m_finalEvent.SetActive(true);
        m_alliesGO.SetActive(true);
        if (!m_finalSpeechUnlocked)
        {
            m_finalEvent.GetComponent<NPCTracker>().ChangeAlliesToCombat();
        }
    }

    private void EnableCarEventConditions()
    {
        NPCTalk.DialogueEnding -= EnableCarEventConditions;
        m_carEventConditionsHandler.SetActive(true);
    }
}