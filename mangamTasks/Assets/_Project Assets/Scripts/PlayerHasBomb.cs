using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHasBomb : MonoBehaviour
{
    public bool HasBomb;
    public bool inCoolDown = false;
    public bool Died;
    public GameObject BombPrefab;

    public ScriptableEventWithintSO newBomberMan;

    private void Start()
    {
        AllPlayers.players.Add(this.gameObject);
       // newBomberMan += AllPlayers.AttachBombToPlayer;
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.GetComponent<PlayerHasBomb>() != null && collision.collider.GetComponent<PlayerHasBomb>().inCoolDown == false && HasBomb)
        {
            collision.collider.GetComponent<PlayerHasBomb>().HasBomb = true;
            FindPlayerOrderInTheList(collision.collider.gameObject);

            StartCoroutine(EnterCooldown(1, collision.collider.gameObject));
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

    int FindPlayerOrderInTheList(GameObject obj)
    {
        for (int i = 0; i < AllPlayers.players.Count; i++)
        {
            if (obj == AllPlayers.players[i])
            {
                //Debug.Log("Player Name " + AllPlayers.players[i].name);
                //Debug.Log("Player Order " + i);
                AllPlayers.AttachBombToPlayer(i);
                return i;
            }
        }
        return 0;
    }

}
