using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private List<Quest> m_mainQuests = new List<Quest>();
    private List<Quest> m_sideQuests = new List<Quest>();


    public void AddMainQuest(Quest newQuest)
    {
        m_mainQuests.Add(newQuest);
    }

    public void AddSideQuest(Quest newQuest)
    {
        m_sideQuests.Add(newQuest);
    }

    public void RemoveMainQuest(Quest completedQuest)
    {
        m_mainQuests.Remove(completedQuest);
    }

    public void RemoveSideQuest(Quest completedQuest)
    {
        m_sideQuests.Remove(completedQuest);
    }
}