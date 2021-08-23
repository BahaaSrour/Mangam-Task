using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPlayers : MonoBehaviour
{
    public static List<GameObject> players;
    private void Awake()
    {
        players = new List<GameObject>(); 
    } 
    
}
