using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationHandler : MonoBehaviour
{
    [SerializeField]
    private Animator m_animator;

    private NavMeshAgent m_agent;
    private bool m_isWounded = false;

    public void NotWounded()
    {
        m_isWounded = false;
        m_animator.SetInteger("AnimationState", 1);
    }

    public void Wounded()
    {
        m_isWounded = true;
        m_animator.SetInteger("AnimationState", 2);
    }

    private void Awake()
    {
        m_agent = GetComponent(typeof(NavMeshAgent)) as NavMeshAgent;
    }

    private void Update()
    {
        if(m_agent.velocity != Vector3.zero && !m_isWounded)
        {
            m_animator.SetInteger("AnimationState", 1);
        }
        else if (m_agent.velocity == Vector3.zero && !m_isWounded)
        {
            m_animator.SetInteger("AnimationState", 0);
        }
    }
}
