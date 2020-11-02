using UnityEngine;

public class InputController : MonoBehaviour
{
    public float LeftStickHorizontal
    {
        get { return m_leftStickHorizontal; }
    }
    private float m_leftStickHorizontal = 0.0f;

    public float LeftStickVertical
    {
        get { return m_leftStickVertical; }
    }
    private float m_leftStickVertical = 0.0f;

    public float RightStickHorizontal
    {
        get { return m_rightStickHorizontal; }
    }
    private float m_rightStickHorizontal = 0.0f;

    public float RightStickVertical
    {
        get { return m_rightStickVertical; }
    }
    private float m_rightStickVertical = 0.0f;

    public bool JumpButtonDown
    {
        get { return m_jumpButtonDown; }
    }
    private bool m_jumpButtonDown = false;

    public bool JumpButton
    {
        get { return m_jumpButton; }
    }
    private bool m_jumpButton = false;

    public bool JumpButtonUp
    {
        get { return m_jumpButtonUp; }
    }
    private bool m_jumpButtonUp = false;
    public bool FireButtonDown
    {
        get { return m_fireButtonDown; }
    }
    private bool m_fireButtonDown = false;

    public bool InteractButtonDown
    {
        get { return m_interactButtonDown; }
    }
    private bool m_interactButtonDown = false;

    public bool InteractButton
    {
        get { return m_interactButton; }
    }
    private bool m_interactButton = false;

    public bool InteractButtonUp
    {
        get { return m_interactButtonUp; }
    }
    private bool m_interactButtonUp = false;

    public bool CrouchButtonDown
    {
        get { return m_crouchButtonDown; }
    }
    private bool m_crouchButtonDown = false;

    public bool EscapeButtonDown
    {
        get { return m_escapeButtonDown; }
    }
    private bool m_escapeButtonDown = false;

    private void Update()
    {
        GetStickInput();
        GetJumpButton();
        GetFireButton();
        GetInteractButton();
        GetCrouchButton();
        GetEscapeButtonDown();
    }

    private void GetStickInput()
    {
        m_leftStickHorizontal = Input.GetAxisRaw("Horizontal");
        m_leftStickVertical = Input.GetAxisRaw("Vertical");

        m_rightStickHorizontal = Input.GetAxisRaw("Mouse X");
        m_rightStickVertical = Input.GetAxisRaw("Mouse Y");
    }

    private void GetJumpButton()
    {
        m_jumpButtonDown = Input.GetButtonDown("Jump");
        m_jumpButton = Input.GetButton("Jump");
        m_jumpButtonUp = Input.GetButtonUp("Jump");
    }

    private void GetFireButton()
    {
        m_fireButtonDown = Input.GetMouseButtonDown(0);
    }

    private void GetInteractButton()
    {
        m_interactButtonDown = Input.GetKeyDown(KeyCode.E);
        m_interactButton = Input.GetKey(KeyCode.E);
        m_interactButtonUp = Input.GetKeyUp(KeyCode.E);
    }

    private void GetCrouchButton()
    {
        m_crouchButtonDown = Input.GetKeyDown(KeyCode.Q);
    }

    private void GetEscapeButtonDown()
    {
        m_escapeButtonDown = Input.GetKeyDown(KeyCode.Escape);
    }
}
