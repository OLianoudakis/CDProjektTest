using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIntroState : State
{
    public override void BeginState()
    {
        gameObject.SetActive(true);
    }

    public override void EndState()
    {
        gameObject.SetActive(false);
    }
}
