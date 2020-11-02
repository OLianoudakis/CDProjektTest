using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField]
    private Transform m_target;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(m_target.forward);
    }

    private void Awake()
    {
        if (!m_target)
        {
            m_target = Camera.main.transform;
        }
    }
}