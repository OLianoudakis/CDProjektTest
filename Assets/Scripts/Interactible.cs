using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactible : MonoBehaviour
{
    public enum InteractibleType { NPCTalk, Door, Readable };
    public bool Targeted
    {
        get { return m_targeted; }
        set { m_targeted = value; }
    }
    private bool m_targeted = false;

    [SerializeField]
    private string m_highlightMessage;
    protected string m_startingMessage;

    [SerializeField]
    protected TextMesh m_meshTextMesh;
    [SerializeField]
    protected InteractibleType m_type;
    public virtual void Interact()
    {

    }

    public virtual void Awake()
    {
        if (!m_meshTextMesh)
            m_meshTextMesh = GetComponentInChildren(typeof(TextMesh)) as TextMesh;
    }

    public virtual void Start()
    {
        m_startingMessage = m_meshTextMesh.text;
    }

    protected virtual void SetType()
    {

    }

    public void OnTargetEnter()
    {
        m_meshTextMesh.text = m_highlightMessage;
    }

    public void OnTargetExit()
    {
        m_meshTextMesh.text = m_startingMessage;
    }

    public InteractibleType Type()
    {
        return m_type;
    }

}