using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicesManager : MonoBehaviour
{
    public delegate void ChoiceOne();
    public static event ChoiceOne FirstChoice;
    public void PublishFirstChoice()
    {
        FirstChoice?.Invoke();
    }

    public delegate void ChoiceTwo();
    public static event ChoiceOne SecondChoice;
    public void PublishSecondChoice()
    {
        SecondChoice?.Invoke();
    }

    public delegate void ChoiceThree();
    public static event ChoiceOne ThirdChoice;
    public void PublishThirdChoice()
    {
        ThirdChoice?.Invoke();
    }

    public delegate void ChoiceFour();
    public static event ChoiceOne FourthChoice;
    public void PublishFourthChoice()
    {
        FourthChoice?.Invoke();
    }
}
