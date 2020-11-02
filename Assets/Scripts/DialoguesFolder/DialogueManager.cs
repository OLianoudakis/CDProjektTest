using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue")]
public class DialogueManager : ScriptableObject
{
    public DialogueNode[] m_allNodes;

    private Dictionary<string, DialogueNode> m_dialogue = new Dictionary<string, DialogueNode>();
    private List<DialogueButton> allKeys = new List<DialogueButton>();

    public void InitDictionary()
    {
        allKeys.Clear();
        m_dialogue.Clear();
        foreach (DialogueNode node in m_allNodes)
        {
            foreach (Message message in node.m_messages)
            {
                if (message.m_dialogueButtons.Length > 0)
                {
                    foreach (DialogueButton dialogueButton in message.m_dialogueButtons)
                    {
                        allKeys.Add(dialogueButton);
                    }
                }
            }
        }

        m_dialogue.Add("FirstKey", m_allNodes[0]);
        if (allKeys.Count > 0)
        {
            for (int i = 0; i < allKeys.Count; i++)
            {
                m_dialogue.Add(allKeys[i].m_buttonMessage, m_allNodes[allKeys[i].TargetNode]);
            }
        }
    }

    public DialogueNode CurrentNode(string key)
    {
        DialogueNode currentNode;
        m_dialogue.TryGetValue(key, out currentNode);
        return currentNode;
    }
}