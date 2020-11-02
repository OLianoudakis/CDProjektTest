using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityForce : MonoBehaviour
{
    public float GravityValue
    {
        set { m_gravityValue = value; }
        get { return m_gravityValue; }
    }
    [SerializeField]
    private float m_gravityValue = -9.81f;

    private GroundChecks m_playerGroundChecks;
    private PlayerTotalVelocity m_playerTotalVelocity;

    private void Awake()
    {
        m_playerGroundChecks = GetComponent(typeof(GroundChecks)) as GroundChecks;
        m_playerTotalVelocity = GetComponent(typeof(PlayerTotalVelocity)) as PlayerTotalVelocity;
    }

    private void FixedUpdate()
    {
        ApplyGravity();
    }

    private void ApplyGravity()
    {
        if (m_playerGroundChecks.IsPlayerGrounded() && m_playerTotalVelocity.TotalVelocity.y < 0.0f)
        {
            m_playerTotalVelocity.TotalVelocity = new Vector3(m_playerTotalVelocity.TotalVelocity.x, -1.0f, m_playerTotalVelocity.TotalVelocity.z);
        }
        m_playerTotalVelocity.TotalVelocity += new Vector3(0.0f, m_gravityValue * Time.fixedDeltaTime, 0.0f);

    }
}