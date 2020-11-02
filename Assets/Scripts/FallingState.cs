using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : State
{
    [SerializeField]
    private float m_gravityValue = -40;

    private GravityForce m_gravityForce;

    public override void BeginState()
    {
        gameObject.SetActive(true);
        m_gravityForce.GravityValue = m_gravityValue;
    }

    public override void EndState()
    {
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        m_gravityForce = transform.parent.parent.GetComponent(typeof(GravityForce)) as GravityForce;
    }
}
