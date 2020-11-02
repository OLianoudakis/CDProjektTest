using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToVictoryCounter : MonoBehaviour
{
    [SerializeField]
    private LevelManager m_levelManager;

    private void OnDisable()
    {
        m_levelManager.IncreaseVictoryPoints();
    }
}
