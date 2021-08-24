using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(menuName ="")]
public class ScriptableEventWithintSO : ScriptableObject
{
    public UnityAction<int> action;

    public void InvokeEvent(int x)
    {
        action.Invoke(x);
    }
}
