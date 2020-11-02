using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField]
    private float m_maxJumpPower = 13.0f;

    private PlayerTotalVelocity m_playerTotalVelocity;

    public void StartJump()
    {
        DoJump();
    }

    private void Awake()
    {
        m_playerTotalVelocity = transform.parent.parent.GetComponent(typeof(PlayerTotalVelocity)) as PlayerTotalVelocity;
    }

    private void DoJump()
    {
        m_playerTotalVelocity.TotalVelocity = new Vector3(m_playerTotalVelocity.TotalVelocity.x,
                                                             m_maxJumpPower,
                                                             m_playerTotalVelocity.TotalVelocity.z);
    }
}
