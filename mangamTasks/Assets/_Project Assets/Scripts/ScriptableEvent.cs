using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName ="SOEvent/Action")]
public class ScriptableEvent : ScriptableObject
{
    public UnityAction action;

    public void InvokeEvent()
    {
        action.Invoke();
    }
        
}
