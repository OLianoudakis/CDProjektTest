using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStats : MonoBehaviour
{
    public int BulletDamage
    {
        set { m_bulletDamage = value; }
        get { return m_bulletDamage; }
    }
    [SerializeField]
    private int m_bulletDamage = 10;
}
