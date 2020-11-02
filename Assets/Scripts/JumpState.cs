using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    [SerializeField]
    private float m_gravityValue = -25;

    private Jump m_jump;

    private GravityForce m_gravityForce;

    public override void BeginState()
    {
        gameObject.SetActive(true);
        m_gravityForce.GravityValue = m_gravityValue;
        m_jump.StartJump();
    }

    public override void EndState()
    {
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        m_jump = GetComponent(typeof(Jump)) as Jump;
        m_gravityForce = transform.parent.parent.GetComponent(typeof(GravityForce)) as GravityForce;

    }
}