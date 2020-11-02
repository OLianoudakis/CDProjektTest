using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NPCTalk : Interactible
{
    public DialogueManager m_dialogue;

    private CanvasStateMachine m_canvasStateMachine;
    private CanvasTalkingState m_canvasTalkingState;
    private CanvasDefaultState m_canvasDefaultState;

    private Text m_dialogueText;
    private Text m_characterNameText;

    private DialogueNode m_currentNode;
    private int m_currentNodeIndex = 0;
    private string m_currentKey = "FirstKey";

    private bool m_progressTextWithClick = false;

    public delegate void DialogueEnd();
    public static event DialogueEnd DialogueEnding;

    public void ExitConversationEarly()
    {
        m_canvasStateMachine.SetState(m_canvasDefaultState);
        m_currentNodeIndex = 0;
    }

    public void EndDialogue()
    {
        m_canvasStateMachine.SetState(m_canvasDefaultState);
        DialogueEnding?.Invoke();
    }

    public void ProgressMessageWithClick()
    {
        if (m_progressTextWithClick)
        {
            ShowNextMessage();
        }
    }

    public override void Interact()
    {
        m_canvasStateMachine.SetState(m_canvasTalkingState);
          GetNextNode(m_currentKey);
    }

    public override void Awake()
    {
        if (!m_meshTextMesh)
            m_meshTextMesh = GetComponentInChildren(typeof(TextMesh)) as TextMesh;

        m_startingMessage = m_meshTextMesh.text;

        m_dialogueText = GameObject.Find("DialogueText").GetComponent(typeof(Text)) as Text;
        m_characterNameText = GameObject.Find("CharacterNameText").GetComponent(typeof(Text)) as Text;

        m_canvasStateMachine = GameObject.Find("Canvas").GetComponent(typeof(CanvasStateMachine)) as CanvasStateMachine;
        m_canvasTalkingState = GameObject.Find("Canvas").GetComponentInChildren(typeof(CanvasTalkingState)) as CanvasTalkingState;
        m_canvasDefaultState = GameObject.Find("Canvas").GetComponentInChildren(typeof(CanvasDefaultState)) as CanvasDefaultState;

        m_dialogue.InitDictionary();
    }

    public override void Start()
    {
        m_startingMessage = m_meshTextMesh.text;
        m_type = InteractibleType.NPCTalk;      
    }


    private void GetNextNode(string key)
    {
        m_currentNode = m_dialogue.CurrentNode(key);
        m_currentNodeIndex = 0;
        ShowNextMessage();
        //StartCoroutine(WaitForMouseButtonDown());
    }

    private void ShowNextMessage()
    {
        if (m_currentNodeIndex >= m_currentNode.m_messages.Count)
        {
            EndDialogue();
            return;
        }
        m_progressTextWithClick = true;
        m_dialogueText.text = m_currentNode.m_messages[m_currentNodeIndex].m_messageText;
        m_characterNameText.text = m_currentNode.m_messages[m_currentNodeIndex].m_characterName;

        if (m_currentNode.m_messages[m_currentNodeIndex].m_dialogueButtons.Length > 0)
        {
            m_progressTextWithClick = false;

            for (int i = 0; i < m_currentNode.m_messages[m_currentNodeIndex].m_dialogueButtons.Length; i++)
            {
                m_currentNode.m_messages[m_currentNodeIndex].m_dialogueButtons[i].InitButton(i);
            }
            DialogueButton.PChosen += OptionChosen;
        }
        else
        {
            m_currentNodeIndex++;
        }
    }

    private void OptionChosen()
    {
        DialogueButton.PChosen -= OptionChosen;
        bool foundChosen = false;
        for (int i = 0; i < m_currentNode.m_messages[m_currentNodeIndex].m_dialogueButtons.Length; i++)
        {
            if (m_currentNode.m_messages[m_currentNodeIndex].m_dialogueButtons[i].IsChosen)
            {
                m_currentKey = m_currentNode.m_messages[m_currentNodeIndex].m_dialogueButtons[i].m_buttonMessage;
                foundChosen = true;
            }
        }

        if (foundChosen)
        {
            for (int i = 0; i < m_currentNode.m_messages[m_currentNodeIndex].m_dialogueButtons.Length; i++)
            {
                m_currentNode.m_messages[m_currentNodeIndex].m_dialogueButtons[i].ClearButton();
            }
            GetNextNode(m_currentKey);
        }
        else
        {
            Debug.Log("chosen not found");
        }
    }
}