using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHasBomb : MonoBehaviour
{
    public bool HasBomb;
    public bool inCoolDown=false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHasBomb>() != null&& other.GetComponent<PlayerHasBomb>().inCoolDown ==false&&HasBomb )
        {
            other.GetComponent<PlayerHasBomb>() . HasBomb = true; 
            StartCoroutine(EnterCooldown(3));
            HasBomb = false;
        }

    }

    IEnumerator EnterCooldown(float CooldownTime)
    {
        inCoolDown = true;

        yield return new WaitForSeconds(CooldownTime); 
        inCoolDown = false;
            
    }

}
