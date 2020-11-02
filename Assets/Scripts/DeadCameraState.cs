using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadCameraState : StateCamera
{
    [SerializeField]
    private LevelManager m_levelManager;
    public override void BeginState()
    {
        gameObject.SetActive(true);
    }

    public override void EndState()
    {
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
