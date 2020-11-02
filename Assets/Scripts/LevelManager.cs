using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private CanvasStateMachine m_canvasStateMachine;
    [SerializeField]
    private State m_pauseStateCanvas;
    [SerializeField]
    private int m_requiredVictoryPoints = 16;

    private CursorLockMode previousMode = CursorLockMode.None;
    private State m_previousState;

    private int m_victoryPoints = 0;

    public void IncreaseVictoryPoints()
    {
        m_victoryPoints++;
        if (m_victoryPoints >= m_requiredVictoryPoints)
        {
            StartCoroutine(Victory());
        }
    }

    public void OnlyPause()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0.0f;
    }

    public void PauseGame()
    {
        m_previousState = m_canvasStateMachine.GetCurrentState();
        m_canvasStateMachine.SetState(m_pauseStateCanvas);
        previousMode = Cursor.lockState;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0.0f;
    }

    public void UnpauseGame()
    {
        Cursor.lockState = previousMode;
        m_canvasStateMachine.SetState(m_previousState);
        Time.timeScale = 1.0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator Victory()
    {
        yield return new WaitForSeconds(3.0f);
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Victory");
    }
}
