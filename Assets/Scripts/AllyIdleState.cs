using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyIdleState : State
{
    public override void BeginState()
    {
        gameObject.SetActive(true);
    }

    public override void EndState()
    {
        transform.parent.parent.gameObject.layer = 13;
        gameObject.SetActive(false);
    }
}