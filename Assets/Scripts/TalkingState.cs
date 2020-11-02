using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingState : State
{
    private Talking m_talking;
    private PlayerTotalVelocity m_totalVelocity;
    public override void BeginState()
    {
        gameObject.SetActive(true);
        m_totalVelocity.TotalVelocity = Vector3.zero;
        m_talking.Init();
    }

    public override void EndState()
    {
        gameObject.SetActive(false);
        m_talking.End();
    }

    private void Awake()
    {
        m_talking = GetComponent(typeof(Talking)) as Talking;
        m_totalVelocity = transform.parent.parent.GetComponent(typeof(PlayerTotalVelocity)) as PlayerTotalVelocity;
    }
}