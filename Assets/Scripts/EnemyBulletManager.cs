using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("ouchie ouch");
            (other.GetComponent(typeof(CharacterStats)) as CharacterStats).ApplyDamage((other.GetComponent(typeof(BulletStats)) as BulletStats).BulletDamage);
            Destroy(gameObject);
        }
    }
}
