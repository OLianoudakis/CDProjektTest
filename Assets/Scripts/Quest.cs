using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest")]
public class Quest : ScriptableObject
{
    [HideInInspector]
    public enum QuestType { Main, Side };
    [HideInInspector]
    public enum ObjectiveType { Kills, Talk, Reach, GetItem };

    public string m_questName;
    [TextArea(3, 5)]
    public string m_questDescription;

    public QuestType m_questType;
    public ObjectiveType m_objectiveType;

    public string m_talkToNPCName;

    public int[] m_killsNumber; //pair with type of enemy
    public int[] m_typeOfEnemy;

    public Transform m_reachTransform;

    //Temp (replace with Item Class)
    public Object m_itemRequired;
}
