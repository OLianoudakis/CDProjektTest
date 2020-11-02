using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingCameraState : StateCamera
{
    private TalkingCamera m_talkingCamera;

    public override void BeginState()
    {
        gameObject.SetActive(true);
        m_talkingCamera.Init();
    }

    public override void EndState()
    {
        m_talkingCamera.StopLookAtRoutine();
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        m_talkingCamera = GetComponent(typeof(TalkingCamera)) as TalkingCamera;
    }
}
