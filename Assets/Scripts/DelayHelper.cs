using UnityEngine;
using System.Collections;
using System;
public static class DelayHelper  
{
    public static Coroutine DelayAction(this MonoBehaviour monobehaviour, Action action, float delayDuration)
    {
        return monobehaviour.StartCoroutine(DelayActionRoutine(action, delayDuration));
    }

    private static IEnumerator DelayActionRoutine(Action action, float time)
    {
        yield return new WaitForSeconds(time);
        action();
    }

}
