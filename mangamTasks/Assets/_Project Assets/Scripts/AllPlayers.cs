using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPlayers : MonoBehaviour
{
    public ScriptableEvent BombActivator;
    public static List<GameObject> players;
    private void Awake()
    {
        players = new List<GameObject>(); 
    }

    private void Start()
    {
       // BombActivator.action += this;
    }



}
