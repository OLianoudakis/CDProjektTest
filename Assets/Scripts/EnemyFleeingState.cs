using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFleeingState : State
{
    [SerializeField]
    private AnimationHandler m_animHandler;

    private EnemyFleeing m_enemyFleeing;

    public override void BeginState()
    {
        gameObject.SetActive(true);
        m_enemyFleeing.Init();
        m_animHandler.NotWounded();
    }

    public override void EndState()
    {
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        m_enemyFleeing = GetComponent(typeof(EnemyFleeing)) as EnemyFleeing;
    }
}
