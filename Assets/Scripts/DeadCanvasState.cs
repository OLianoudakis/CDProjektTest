using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadCanvasState : State
{
    public override void BeginState()
    {
        GetComponent<CanvasGroup>().alpha = 1.0f;
        GetComponent<CanvasGroup>().interactable = true;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public override void EndState()
    {
        GetComponent<CanvasGroup>().alpha = 0.0f;
        GetComponent<CanvasGroup>().interactable = false;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}
