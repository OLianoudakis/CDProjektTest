using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private CharacterStats m_characterStats;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Bullet"))
        {
            m_characterStats.ApplyDamage((other.GetComponent(typeof(BulletStats)) as BulletStats).BulletDamage);
            Destroy(other.gameObject);
        }

        if (other.tag.Equals("Ammo") && gameObject.name.Equals("Player"))
        {
            Destroy(other.gameObject);
            FindFireGun();
        }
    }

    private static void FindFireGun()
    {
        foreach (FireGun go in Resources.FindObjectsOfTypeAll(typeof(FireGun)) as FireGun[])
        {
            if (go.gameObject.activeSelf)
                go.PickUpAmmo();
        }
    }

    private void Awake()
    {
        m_characterStats = GetComponent(typeof(CharacterStats)) as CharacterStats;
    }
}