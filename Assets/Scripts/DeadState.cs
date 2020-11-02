using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    [SerializeField]
    private CanvasStateMachine m_canvasStateMachine;
    [SerializeField]
    private State m_gameOverState;

    [SerializeField]
    private StateMachineCamera m_cameraStateMachine;
    [SerializeField]
    private StateCamera m_cameraNextState;

    [SerializeField]
    private LevelManager m_levelManager;

    public override void BeginState()
    {
        gameObject.SetActive(true);
        m_canvasStateMachine.SetState(m_gameOverState);
        m_cameraStateMachine.SetState(m_cameraNextState);
        m_levelManager.OnlyPause();
    }

    public override void EndState()
    {
        gameObject.SetActive(false);
    }
}
