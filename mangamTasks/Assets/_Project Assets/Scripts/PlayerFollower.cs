using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public Transform player;

    Transform tr;
    private void Start()
    {
        tr=this.transform;
    }
    private void Update()
    {
        tr.position = player.position;
    }
}
