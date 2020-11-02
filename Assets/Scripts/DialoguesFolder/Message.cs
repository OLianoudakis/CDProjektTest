using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Message")]
public class Message : ScriptableObject
{
    public string m_characterName;
    [TextArea(3, 10)]
    public string m_messageText;
    public DialogueButton[] m_dialogueButtons;
    //TODO: Give Quest
    //TODO: Give Reward
    public void InitMessageButtons()
    {
        if (m_dialogueButtons.Length > 0)
        {
            for (int i = 0; i < m_dialogueButtons.Length; i++)
            {
                m_dialogueButtons[i].InitButton(i);
            }
        }
    }
    
    public void ClearMessageButtons()
    {
        m_messageText = null;
        if (m_dialogueButtons.Length > 0)
        {
            for (int i = 0; i < m_dialogueButtons.Length; i++)
            {
                m_dialogueButtons[i].ClearButton();
            }
        }
    }
}