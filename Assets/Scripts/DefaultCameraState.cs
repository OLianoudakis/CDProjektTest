using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultCameraState : StateCamera
{
    private MouseLook m_mouseLook;

    public override void BeginState()
    {
        gameObject.SetActive(true);
        m_mouseLook.Init();
    }

    public override void EndState()
    {
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        m_mouseLook = GetComponent(typeof(MouseLook)) as MouseLook;
    }
}
