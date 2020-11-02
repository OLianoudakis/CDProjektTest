using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEventDeactivateState : State
{
    public override void BeginState()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
