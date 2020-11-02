using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    private float m_mouseSensitivity = 100.0f;

    private Transform m_playerTransform;
    private InputController m_inputController;

    private float m_xRotation = 0.0f;
    
    public void Init()
    {
        CursorState();
    }

    private void CursorState()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Awake()
    {
        m_playerTransform = transform.parent.parent;
        m_inputController = transform.parent.parent.GetComponent(typeof(InputController)) as InputController;
    }

    private void FixedUpdate()
    {
        float mouseX = m_inputController.RightStickHorizontal * m_mouseSensitivity * Time.fixedDeltaTime;
        float mouseY = m_inputController.RightStickVertical * m_mouseSensitivity * Time.fixedDeltaTime;

        m_xRotation -= mouseY;
        m_xRotation = Mathf.Clamp(m_xRotation, -90.0f, 90.0f);

        transform.parent.localRotation = Quaternion.Euler(m_xRotation, 0.0f, 0.0f);
        m_playerTransform.Rotate(Vector3.up * mouseX);
    }
}