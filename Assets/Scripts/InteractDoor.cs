using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDoor : Interactible
{
    [SerializeField]
    private Animator m_doorAnimator;

    private bool m_doorIsOpen = false;

    public override void Interact()
    {
        //OpenDoor();
        StartCoroutine(DoorOpenDelay());
        NPCTalk.DialogueEnding += CloseDoor;
    }

    private void OpenDoor()
    {
        if (!m_doorIsOpen)
        {
            m_doorAnimator.SetTrigger("OpenDoor");
            m_doorIsOpen = true;
        }
    }
    public void CloseDoor()
    {
        if (m_doorIsOpen)
        {
            m_doorAnimator.SetTrigger("CloseDoor");
            m_doorIsOpen = false;
            NPCTalk.DialogueEnding -= CloseDoor;
        }
    }

    private IEnumerator DoorOpenDelay()
    {
        yield return new WaitForSeconds(1.5f);
        OpenDoor();
    }
}