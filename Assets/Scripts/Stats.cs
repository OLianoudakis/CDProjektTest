using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stat Sheet")]
public class Stats : ScriptableObject
{
    public int HP
    {
        get { return m_HP; }
    }
    [SerializeField]
    private int m_HP = 50;

    public int Shield
    {
        get { return m_Shield; }
    }
    [SerializeField]
    private int m_Shield = 0;
}