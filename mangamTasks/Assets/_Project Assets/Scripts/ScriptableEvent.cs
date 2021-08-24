using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScriptableEvent : MonoBehaviour
{
    public UnityAction action;

    public void InvokeEvent()
    {
        action.Invoke();
    }
        
}
