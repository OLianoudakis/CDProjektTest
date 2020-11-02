using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNearestTarget : MonoBehaviour
{
    [SerializeField]
    private bool m_getAllyList = false;

    private AttackAI m_attackAI;
    private NPCTracker m_npcTracker;
    private Transform m_objectTrasform;
    private Transform startingClosestObject;

    private void OnEnable()
    {
        m_attackAI = GetComponent(typeof(AttackAI)) as AttackAI;
        m_npcTracker = transform.parent.parent.parent.parent.GetComponent(typeof(NPCTracker)) as NPCTracker;
        m_objectTrasform = transform.parent.parent;
        startingClosestObject = FindObjectOfType<ClosestObjectInitTagScript>().transform;
    }

    private void Update()
    {
        List<GameObject> gameObjects = m_npcTracker.GetList(m_getAllyList);
        Transform closestObject = startingClosestObject;
        bool foundFirstClosest = false;
        for (int i = 0; i < gameObjects.Count; i++)
        {
            if (gameObjects[i].activeSelf)
            {
                if (!foundFirstClosest)
                {
                    foundFirstClosest = true;
                    closestObject = gameObjects[i].transform;
                }
                else
                {
                    if (Vector3.Distance(gameObjects[i].transform.position, m_objectTrasform.position) <
                        Vector3.Distance(closestObject.transform.position, m_objectTrasform.position))
                    {
                        closestObject = gameObjects[i].transform;
                    }
                }
            }
        }
        if (closestObject != startingClosestObject)
            m_attackAI.ChangeTarget(closestObject);
    }
}
