using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForPauseGame : MonoBehaviour
{
    [SerializeField]
    private LevelManager m_levelManager;

    private InputController m_inputController;

    private void Awake()
    {
        m_inputController = transform.parent.parent.GetComponent(typeof(InputController)) as InputController;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_inputController.EscapeButtonDown)
        {
            if (Time.timeScale > 0.0f)
            {
                m_levelManager.PauseGame();
            }
            else
            {
                m_levelManager.UnpauseGame();
            }
        }
    }
}