using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarEventConditionsHandler : MonoBehaviour
{
    [SerializeField]
    private int m_timeLeftToChangeEventState = 300;
    [SerializeField]
    private Text m_mainQuest;
    [SerializeField]
    private Text m_sideQuest;

    private float m_endTime = 0.0f;

    private EventsManager m_eventsManager;
    public int m_enemiesDead = 0;

    private void SwitchToFinalEvent()
    {
        m_mainQuest.text = "Talk to the neighbors";
        m_sideQuest.text = " ";
        m_eventsManager.SwitchToFinalEvent();
        gameObject.SetActive(false);
    }

    private void UpdateDeadEnemies()
    {
        m_enemiesDead++;
        if (m_enemiesDead >= 3)
        {
            SwitchToFinalEvent();
        }
    }

    private void OnEnable()
    {
        EnemyCharacterStats.EnemyDead += UpdateDeadEnemies;
        NPCTalk.DialogueEnding += SwitchToFinalEvent;
    }

    private void OnDisable()
    {
        EnemyCharacterStats.EnemyDead -= UpdateDeadEnemies;
        NPCTalk.DialogueEnding -= SwitchToFinalEvent;
    }

    private void Awake()
    {
        m_eventsManager = transform.parent.parent.GetComponent(typeof(EventsManager)) as EventsManager;

    }
    private void Start()
    {
        m_endTime = Time.time + m_timeLeftToChangeEventState;
    }

    private void Update()
    {
        m_timeLeftToChangeEventState = (int)(m_endTime - Time.time);
        if (m_timeLeftToChangeEventState < 0)
        {
            m_timeLeftToChangeEventState = 0;
            SwitchToFinalEvent();
        }
    }
}
