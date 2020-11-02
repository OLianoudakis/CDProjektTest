using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecks : MonoBehaviour
{
    public Vector3 GroundNormal
    {
        get { return m_groundNormal; }
    }
    private Vector3 m_groundNormal;

    public float GroundAngle
    {
        get { return m_groundAngle; }
    }
    private float m_groundAngle;

    public GameObject RayHitObject
    {
        get { return m_rayHitObject; }
    }
    private GameObject m_rayHitObject;

    [SerializeField]
    private float m_groundRayDistance = 5.0f;
    [SerializeField]
    private LayerMask m_groundRayLayerMask = 0;

    public bool m_playerIsGrounded = false;

    public bool IsPlayerGrounded()
    {
        return m_playerIsGrounded;
    }

    private void Update()
    {
        CheckIfGrounded();
    }

    private void CheckIfGrounded()
    {
        Ray groundRay = new Ray(transform.position, Vector3.down);
        Ray groundRay2 = new Ray(new Vector3(transform.position.x + 0.3f, transform.position.y, transform.position.z + 0.3f), Vector3.down);
        Ray groundRay3 = new Ray(new Vector3(transform.position.x + 0.3f, transform.position.y, transform.position.z - 0.3f), Vector3.down);
        Ray groundRay4 = new Ray(new Vector3(transform.position.x - 0.3f, transform.position.y, transform.position.z + 0.3f), Vector3.down);
        Ray groundRay5 = new Ray(new Vector3(transform.position.x - 0.3f, transform.position.y, transform.position.z - 0.3f), Vector3.down);
        RaycastHit groundRayHit = new RaycastHit();
        RaycastHit groundRayHit2 = new RaycastHit();
        RaycastHit groundRayHit3 = new RaycastHit();
        RaycastHit groundRayHit4 = new RaycastHit();
        RaycastHit groundRayHit5 = new RaycastHit();
        m_playerIsGrounded = Physics.Raycast(groundRay, out groundRayHit, m_groundRayDistance, m_groundRayLayerMask)
                            || Physics.Raycast(groundRay2, out groundRayHit2, m_groundRayDistance, m_groundRayLayerMask)
                            || Physics.Raycast(groundRay3, out groundRayHit3, m_groundRayDistance, m_groundRayLayerMask)
                            || Physics.Raycast(groundRay4, out groundRayHit4, m_groundRayDistance, m_groundRayLayerMask)
                            || Physics.Raycast(groundRay5, out groundRayHit5, m_groundRayDistance, m_groundRayLayerMask);
        if (m_playerIsGrounded)
        {
            RaycastHit tempGroundHit = new RaycastHit();
            if (groundRayHit.collider != null)
            {
                tempGroundHit = groundRayHit;
            }
            else if (groundRayHit2.collider != null)
            {
                tempGroundHit = groundRayHit2;
            }
            else if (groundRayHit3.collider != null)
            {
                tempGroundHit = groundRayHit3;
            }
            else if (groundRayHit4.collider != null)
            {
                tempGroundHit = groundRayHit4;
            }
            else if (groundRayHit5.collider != null)
            {
                tempGroundHit = groundRayHit5;
            }
            m_groundNormal = tempGroundHit.normal;
            m_groundAngle = Vector3.Angle(tempGroundHit.normal, Vector3.up);
            m_rayHitObject = tempGroundHit.collider.gameObject;
        }
    }
}
