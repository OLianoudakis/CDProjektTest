using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutOfRoomCheck : MonoBehaviour
{
    [SerializeField]
    private Text m_mainQuestText;
    [SerializeField]
    private Text m_sideQuesText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            m_mainQuestText.text = "Explore the building";
            m_sideQuesText.text = "Bonus: Talk to the neighbors";
            gameObject.SetActive(false);
        }
    }
}
