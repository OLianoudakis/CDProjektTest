using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroEventConditionsHandler : MonoBehaviour
{
    [SerializeField]
    private int m_requiredNPCsForCarEvent = 4;
    [SerializeField]
    private int m_requiredNumberForSecretFinalEvent = 4;
    [SerializeField]
    private EventsManager m_eventsManager;
    [SerializeField]
    private int m_timeLeftToChangeEventState = 300;
    private float m_endTime = 0.0f;

    private int m_talkedToNPCs = 0;
    private int m_secretConvosUnlocked = 0;

    public void UpdateTalkedNPCs()
    {
        m_talkedToNPCs++;
        if (m_talkedToNPCs >= m_requiredNPCsForCarEvent)
        {
            SwitchToCarEvent();
        }
    }

    public void UpdateSecretConvosCounter()
    {
        m_secretConvosUnlocked++;
        if (m_secretConvosUnlocked >= m_requiredNumberForSecretFinalEvent)
        {
            m_eventsManager.SecretEventUnlocked = true;
        }
    }

    private void SwitchToCarEvent()
    {
        EnemyCharacterStats.TookFirstShot -= SwitchToCarEvent;
        m_eventsManager.SwitchToCarEvent();
        gameObject.SetActive(false);
    }

    private void Start()
    {
        m_endTime = Time.time + m_timeLeftToChangeEventState;
        EnemyCharacterStats.TookFirstShot += SwitchToCarEvent;
    }

    // Update is called once per frame
    void Update()
    {
        m_timeLeftToChangeEventState = (int)(m_endTime - Time.time);
        if (m_timeLeftToChangeEventState < 0)
        {
            m_timeLeftToChangeEventState = 0;
            //SwitchToCarEvent();
        }
    }
}
