using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTracker : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> m_allies = new List<GameObject>();
    [SerializeField]
    private List<GameObject> m_enemies = new List<GameObject>();
    [SerializeField]
    private GameObject m_enemiesGO;
    [SerializeField]
    private Text m_mainQuest;

    public List<GameObject> GetList(bool ally)
    {
        if(ally)
        {
            return m_allies;
        }
        else
        {
            return m_enemies;
        }
    }

    public void ChangeAlliesToCombat()
    {
        m_mainQuest.text = "Defend the building";
        NPCTalk.DialogueEnding -= ChangeAlliesToCombat;
        for (int i = 0; i < m_allies.Count; i++)
        {
            if (!m_allies[i].gameObject.tag.Equals("Player"))
            {
                StateMachine allyMachine = m_allies[i].GetComponentInChildren<StateMachine>();
                EnemyCombatState state = allyMachine.transform.Find("Combat").GetComponent<EnemyCombatState>();
                allyMachine.SetState(state);
            }
        }
        m_enemiesGO.SetActive(true);
    }

    private void OnEnable()
    {
        GameObject player = FindObjectOfType<PlayerTotalVelocity>().gameObject;
        m_allies.Add(player);
        NPCTalk.DialogueEnding += ChangeAlliesToCombat;
    }

    private void Start()
    {
        m_enemiesGO.SetActive(false);
    }
}