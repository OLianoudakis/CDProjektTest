using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTotalVelocity : MonoBehaviour
{
    private CharacterController m_characterController;

    public Vector3 TotalVelocity
    {
        set { m_totalVelocity = value; }
        get { return m_totalVelocity; }
    }
    private Vector3 m_totalVelocity = Vector3.zero;

    public Vector3 PlayerPosition
    {
        set { m_playerPosition = value; }
        get { return m_playerPosition; }
    }
    private Vector3 m_playerPosition;

    public bool UseCharacterController
    {
        set { m_useCharacterController = value; }
        get { return m_useCharacterController; }
    }
    [SerializeField]
    private bool m_useCharacterController = true;

    private void Awake()
    {
        m_characterController = GetComponent(typeof(CharacterController)) as CharacterController;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        m_characterController.Move(new Vector3(m_totalVelocity.x , m_totalVelocity.y, m_totalVelocity.z) * Time.fixedDeltaTime);
    }
}
