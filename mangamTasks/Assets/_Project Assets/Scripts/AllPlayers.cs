using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPlayers : MonoBehaviour
{
    public static GameObject[] players;
    void Start()
    {
        if (players == null)
            players = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < players.Length; i++)
        {
            Debug.Log(players[i].name);
        }
    }

    
}
