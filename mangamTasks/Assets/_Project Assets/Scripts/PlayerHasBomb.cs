using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHasBomb : MonoBehaviour
{
    public bool HasBomb;
    public bool inCoolDown = false;

    private void Start()
    {
        AllPlayers.players.Add(this.gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.GetComponent<PlayerHasBomb>() != null && collision.collider.GetComponent<PlayerHasBomb>().inCoolDown == false && HasBomb)
        {
            collision.collider.GetComponent<PlayerHasBomb>().HasBomb = true;
            StartCoroutine(EnterCooldown(3, collision.collider.gameObject));
            HasBomb = false;
        }
    }

    IEnumerator EnterCooldown(float CooldownTime, GameObject newBomberman)
    {
        float speed = 0;
        inCoolDown = true;
        //Stop NPC Movement
        if (newBomberman.GetComponent<NPC_BaseClass>() != null)
        {
            speed = newBomberman.GetComponent<NPC_BaseClass>().navMeshAgent.speed;
            newBomberman.GetComponent<NPC_BaseClass>().navMeshAgent.speed = 0;
        }

        //Stop player Movement
        else if (newBomberman.GetComponent<PlayerMovements>() != null)
        {
            speed = newBomberman.GetComponent<PlayerMovements>().speed;
            newBomberman.GetComponent<PlayerMovements>().speed = 0;
        }

        yield return new WaitForSeconds(CooldownTime);
        inCoolDown = false;
       
        //Start NPC Moving
        if (newBomberman.GetComponent<NPC_BaseClass>() != null)
            newBomberman.GetComponent<NPC_BaseClass>().navMeshAgent.speed = speed;
       
        //Start Player Moving
        else if (newBomberman.GetComponent<PlayerMovements>() != null)
            newBomberman.GetComponent<PlayerMovements>().speed = speed;

    }

}
