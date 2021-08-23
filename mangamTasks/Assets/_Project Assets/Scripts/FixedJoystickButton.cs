using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FixedJoystickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    protected bool pressed = false;
    void Start()
    {

    }
    void Update()
    {

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }
}
