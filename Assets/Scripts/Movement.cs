using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float m_speed = 20.0f;

    private PlayerTotalVelocity m_playerTotalVelocity;
    private InputController m_inputController;
    private Transform m_playerTransform;

    private void Awake()
    {
        m_playerTotalVelocity = transform.parent.parent.GetComponent(typeof(PlayerTotalVelocity)) as PlayerTotalVelocity;
        m_inputController = transform.parent.parent.GetComponent(typeof(InputController)) as InputController;
        m_playerTransform = transform.parent.parent;
    }

    private void FixedUpdate()
    {
        float x = m_inputController.LeftStickHorizontal;
        float z = m_inputController.LeftStickVertical;

        float speed = m_speed;
        if (x != 0.0f && z != 0.0f)
        {
            speed = m_speed / 1.5f;
        }
        else
        {
            speed = m_speed;
        }

        Vector3 move = m_playerTransform.right * x + m_playerTransform.forward * z;
        Vector3 newVelocity = move * speed;
        newVelocity.y = m_playerTotalVelocity.TotalVelocity.y;

        m_playerTotalVelocity.TotalVelocity = newVelocity;
    }
}
