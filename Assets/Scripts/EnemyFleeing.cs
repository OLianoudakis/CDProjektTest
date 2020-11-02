using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFleeing : MonoBehaviour
{
    [SerializeField]
    private Transform m_fleetingPoint;

    private NavMeshAgent m_agent;

    public void Init()
    {
        m_agent.SetDestination(m_fleetingPoint.position);     
    }

    private void Awake()
    {
        m_agent = transform.parent.parent.GetComponent(typeof(NavMeshAgent)) as NavMeshAgent;
    }
}