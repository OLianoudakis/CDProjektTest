using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talking : MonoBehaviour
{
    private InputController m_inputController;
    private NPCTalk m_currentTalkingNPC;

    private StateMachine m_playerStateMachine;
    private GroundMovementState m_groundMovementState;

    private StateMachineCamera m_cameraStateMachine;
    private TalkingCameraState m_talkingCameraState;
    private DefaultCameraState m_defaultCameraState;

    public void Init()
    {
        m_currentTalkingNPC = (transform.parent.parent.GetComponent(typeof(TalkingNPC)) as TalkingNPC).CurrentTalkingNPC;
        m_cameraStateMachine.SetState(m_talkingCameraState);
        (m_talkingCameraState.gameObject.GetComponent(typeof(TalkingCamera)) as TalkingCamera).LookAtTarget(m_currentTalkingNPC.transform);
        NPCTalk.DialogueEnding += DialogueEnd;
    }

    public void End()
    {
        NPCTalk.DialogueEnding -= DialogueEnd;
    }

    private void Awake()
    {
        m_inputController = transform.parent.parent.GetComponent(typeof(InputController)) as InputController;
        m_playerStateMachine = transform.parent.GetComponent(typeof(StateMachine)) as StateMachine;
        m_groundMovementState = transform.parent.GetComponentInChildren(typeof(GroundMovementState)) as GroundMovementState;

        m_cameraStateMachine = transform.parent.parent.GetComponentInChildren(typeof(StateMachineCamera)) as StateMachineCamera;
        m_talkingCameraState = m_cameraStateMachine.GetComponentInChildren(typeof(TalkingCameraState)) as TalkingCameraState;
        m_defaultCameraState = m_cameraStateMachine.GetComponentInChildren(typeof(DefaultCameraState)) as DefaultCameraState;
    }

    private void Update()
    {
        if (m_inputController.FireButtonDown)
        {
            m_currentTalkingNPC.ProgressMessageWithClick();
        }

        if (m_inputController.EscapeButtonDown)
        {
            m_currentTalkingNPC.ExitConversationEarly();
            DialogueEnd();
        }
    }

    private void DialogueEnd()
    {
        m_playerStateMachine.SetState(m_groundMovementState);
        m_cameraStateMachine.SetState(m_defaultCameraState);
    }
}