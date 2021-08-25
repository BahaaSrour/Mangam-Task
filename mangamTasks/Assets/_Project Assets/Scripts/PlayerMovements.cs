using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof( AudioSource))]
public class PlayerMovements : MonoBehaviour
{
    public Joystick Joystick;
    public FixedJoystickButton FixedJoystickButton;
    Rigidbody rb;
    public float speed = 100;

    public AudioClip movingStepsSound;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Joystick = FindObjectOfType<Joystick>();
        //audioSource.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(Joystick.Horizontal * speed, rb.velocity.y, Joystick.Vertical * speed);
        if ((Mathf.Abs(rb.velocity.x )> 3 || Mathf.Abs(rb.velocity.z) > 3)  && audioSource.isPlaying == false)
            audioSource.PlayOneShot(movingStepsSound);


    }
}
