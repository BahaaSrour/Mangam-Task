using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public Joystick Joystick;
    public FixedJoystickButton FixedJoystickButton;
    Rigidbody rb;
    public float speed = 100;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Joystick = FindObjectOfType<Joystick>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(Joystick.Horizontal * speed, rb.velocity.y, Joystick.Vertical * speed);
    }
}
