using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWoundedState : State
{
    [SerializeField]
    private ChangeStateBasedOnHealth m_changeCharacterBasedOnDeath;
    [SerializeField]
    private AnimationHandler m_animator;

    private NavMeshAgent m_agent;

    public override void BeginState()
    {
        gameObject.SetActive(true);
        m_agent.isStopped = true;
        m_agent.ResetPath();
        m_agent.velocity = Vector3.zero;
        m_agent.gameObject.tag = "Interactible";
        m_agent.gameObject.layer = 0;
        m_animator.Wounded();
    }

    public override void EndState()
    {
        m_changeCharacterBasedOnDeath.enabled = false;
        transform.parent.parent.gameObject.tag = "Untagged";
        m_agent.gameObject.layer = 11;
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        m_agent = transform.parent.parent.GetComponent(typeof(NavMeshAgent)) as NavMeshAgent;
    }
}