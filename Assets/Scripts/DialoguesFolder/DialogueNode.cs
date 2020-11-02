using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Dialogue Node")]
public class DialogueNode : ScriptableObject
{
    public List<Message> m_messages;
}