using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Choice")]
public class DialogueButton : ScriptableObject
{
    public bool IsChosen
    {
        get { return m_isChosen; }
    }
    private bool m_isChosen = false;

    [TextArea(3,10)]
    public string m_buttonMessage;
    public int TargetNode
    {
        get { return m_targetNode; }
    }
    [SerializeField]
    private int m_targetNode = 0;

    private int m_choiceNumber;

    public void InitButton(int choiceNumber)
    {
        m_isChosen = false;
        m_choiceNumber = choiceNumber;
        GameObject choices = GameObject.Find("Choices");
        Transform button = choices.transform.GetChild(m_choiceNumber);
        button.GetChild(0).GetComponent<Text>().text = m_buttonMessage;
        button.gameObject.SetActive(true);

        switch (m_choiceNumber)
        {
            case 0:
                ChoicesManager.FirstChoice += Chosen;
                break;
            case 1:
                ChoicesManager.SecondChoice += Chosen;
                break;
            case 2:
                ChoicesManager.ThirdChoice += Chosen;
                break;
            case 3:
                ChoicesManager.FourthChoice += Chosen;
                break;
        }
    }

    public void ClearButton()
    {
        GameObject choices = GameObject.Find("Choices");
        Transform button = choices.transform.GetChild(m_choiceNumber);
        button.gameObject.SetActive(false);

        switch (m_choiceNumber)
        {
            case 0:
                ChoicesManager.FirstChoice -= Chosen;
                break;
            case 1:
                ChoicesManager.SecondChoice -= Chosen;
                break;
            case 2:
                ChoicesManager.ThirdChoice -= Chosen;
                break;
            case 3:
                ChoicesManager.FourthChoice -= Chosen;
                break;
        }
    }

    public delegate void PublishChosen();
    public static event PublishChosen PChosen;
    public void Chosen()
    {
        m_isChosen = true;
        PChosen?.Invoke();
    }
}
