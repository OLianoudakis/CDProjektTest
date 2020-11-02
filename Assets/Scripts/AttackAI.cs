using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackAI : MonoBehaviour
{
    [SerializeField]
    private GameObject m_bullet;
    [SerializeField]
    private Transform m_targetTransform;
    [SerializeField]
    private float m_attackDistance = 3.0f;
    [SerializeField]
    private float m_movementSpeed = 4.0f;
    [SerializeField]
    private LayerMask m_layerMask;

    [SerializeField]
    private float m_attackRate = 0.5f;

    [SerializeField]
    private float m_bulletForce = 1000.0f;

    [SerializeField]
    private Transform m_firePoint;

    private NavMeshAgent m_navMeshAgent;

    private float m_attackTime = 0.0f;

    private Rigidbody m_rigidbody;
    private Transform[] m_possibleTargets = new Transform[4];

    private Transform m_gun;

    public void ChangeTarget(Transform newTarget)
    {
        m_targetTransform = newTarget;
        m_possibleTargets[0] = m_targetTransform.Find("PossibleTargetPoints").Find("Target_4");
        m_possibleTargets[1] = m_targetTransform.Find("PossibleTargetPoints").Find("Target_1");
        m_possibleTargets[2] = m_targetTransform.Find("PossibleTargetPoints").Find("Target_2");
        m_possibleTargets[3] = m_targetTransform.Find("PossibleTargetPoints").Find("Target_3");
    }

    private void Awake()
    {
        m_navMeshAgent = transform.parent.parent.GetComponent(typeof(NavMeshAgent)) as NavMeshAgent;
        m_navMeshAgent.stoppingDistance = m_attackDistance;
        m_navMeshAgent.speed = m_movementSpeed;

        m_rigidbody = transform.parent.parent.GetComponent(typeof(Rigidbody)) as Rigidbody;
        m_rigidbody.useGravity = false;
        m_rigidbody.isKinematic = true;

        m_gun = transform.Find("Gun");

        ChangeTarget(m_targetTransform);
    }

    private void Update()
    {
        m_gun.LookAt(m_possibleTargets[0]);
        m_gun.Rotate(90, 0, 0);
        if (m_navMeshAgent.remainingDistance - m_attackDistance < 0.01f)
        {
            if (Time.time > m_attackTime)
            {               
                AIAim();
            }
        }
        MoveAgent();
    }

    private void AIAim()
    {
        m_attackTime = Time.time + m_attackRate;

        Ray ray = new Ray(m_firePoint.position, m_targetTransform.position - m_firePoint.position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, m_layerMask))
        {
            if (hit.transform.tag.Equals("Player") || hit.transform.tag.Equals("Ally") || hit.transform.tag.Equals("Enemy"))
            {
                int randomTarget = Random.Range(0, 3);
                m_gun.LookAt(m_possibleTargets[randomTarget]);
                m_gun.Rotate(90, 0, 0);
                AIShoot();
            }
        }
    }

    private void AIShoot()
    {
        GameObject bulletInstance = Instantiate(m_bullet, m_firePoint);
        bulletInstance.transform.parent = null;
        (bulletInstance.GetComponent(typeof(Rigidbody)) as Rigidbody).velocity = (m_firePoint.TransformDirection(Vector3.up) * m_bulletForce);
    }

    private void MoveAgent()
    {
        m_navMeshAgent.destination = m_targetTransform.position;
        transform.LookAt(new Vector3(m_targetTransform.position.x, transform.position.y, m_targetTransform.position.z));
        m_rigidbody.velocity *= 0.99f;
    }
}
