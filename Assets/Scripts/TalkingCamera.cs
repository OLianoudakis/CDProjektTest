using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingCamera : MonoBehaviour
{
    private Transform m_playerTransform;

    public void LookAtTarget(Transform target)
    {
        StartCoroutine(LerpLookAt(target));
    }

    public void StopLookAtRoutine()
    {
        StopAllCoroutines();
    }

    public void Init()
    {
        CursorState();
    }

    private void CursorState()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void Awake()
    {
        m_playerTransform = transform.parent.parent;
    }

    private IEnumerator LerpLookAt(Transform target)
    {
        bool lerpComplete = false;
        float step = 0.0f;
        Vector3 targetVec3Camera = target.position - transform.parent.position;
        Vector3 targetVec3Player = target.position - m_playerTransform.position;
        targetVec3Player.y = 0.0f;
        Vector3 rotationCamera = Quaternion.LookRotation(targetVec3Camera).eulerAngles;
        Quaternion rotationPlayer = Quaternion.LookRotation(targetVec3Player);
        Quaternion rotationCameraOnlyX = Quaternion.Euler(rotationCamera.x, 
                                                           transform.parent.localRotation.eulerAngles.y, 
                                                           transform.parent.localRotation.eulerAngles.z);
        
        while (!lerpComplete)
        {
            m_playerTransform.rotation = Quaternion.Slerp(m_playerTransform.rotation, rotationPlayer, step);
            step += 0.5f * Time.deltaTime;
            if (step >= 1.0f)
            {
                transform.parent.localRotation = rotationCameraOnlyX;
                m_playerTransform.rotation = rotationPlayer;
                lerpComplete = true;
            }
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }
}
