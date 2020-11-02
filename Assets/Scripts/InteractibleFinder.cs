using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleFinder : MonoBehaviour
{
    [SerializeField]
    private float m_rayDistance = 5.0f;
    [SerializeField]
    private LayerMask m_layerMask;

    private Camera m_playerCamera;
    private StateMachine m_stateMachine;
    private InputController m_inputController;
    private TalkingNPC m_talkingNPC;

    private TalkingState m_talkingState;

    private Interactible m_interactible;
    private Interactible m_newInteractible;

    private void OnDisable()
    {
        //ClearInteractibleTarget();
    }

    private void Awake()
    {
        m_playerCamera = transform.parent.parent.GetComponentInChildren(typeof(Camera)) as Camera;
        m_stateMachine = transform.parent.parent.GetComponentInChildren(typeof(StateMachine)) as StateMachine;
        m_inputController = transform.parent.parent.GetComponent(typeof(InputController)) as InputController;
        m_talkingNPC = transform.parent.parent.GetComponent(typeof(TalkingNPC)) as TalkingNPC;

        m_talkingState = transform.parent.parent.Find("States").GetComponentInChildren(typeof(TalkingState)) as TalkingState;
    }

    private void Update()
    {
        CheckForInteractible();
        CheckForInteract();
    }

    private void CheckForInteractible()
    {
        Ray ray = m_playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit, m_rayDistance, m_layerMask))
        {
            if (raycastHit.collider.gameObject.tag.Equals("Interactible"))
            {
                m_newInteractible = raycastHit.collider.gameObject.GetComponentInChildren(typeof(Interactible)) as Interactible;
                if (!m_newInteractible.Targeted)
                {
                    ChangeInteractibleTarget();
                }
            }
            else
            {
                ClearInteractibleTarget();
            }
        }
        else
        {
            ClearInteractibleTarget();
        }
    }

    private void ChangeInteractibleTarget()
    {
        ClearInteractibleTarget();
        m_interactible = m_newInteractible;
        m_interactible.Targeted = true;
        m_interactible.OnTargetEnter();
    }

    private void ClearInteractibleTarget()
    {
        if (m_interactible)
        {
            m_interactible.Targeted = false;
            m_interactible.OnTargetExit();
            m_interactible = null;
        }
    }

    private void CheckForInteract()
    {
        if (m_interactible && m_inputController.InteractButtonDown)
        {
            if (m_interactible.Type() == Interactible.InteractibleType.NPCTalk)
            {
                m_talkingNPC.CurrentTalkingNPC = m_interactible.gameObject.GetComponent(typeof(NPCTalk)) as NPCTalk;
                m_stateMachine.SetState(m_talkingState);
            }
            m_interactible.Interact();
        }
    }
}