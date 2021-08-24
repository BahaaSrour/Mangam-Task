using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPlayers : MonoBehaviour
{
    public ScriptableEvent newBomberMan;
    public static List<GameObject> players;
    public ScriptableEventWithintSO newBomberManChanged;
    public float bombTimer;
    public GameObject Blocker;

    public AudioClip BombSound;
    public float BombClibDuration;
     AudioSource audioSource;
    float timer;
    [HideInInspector]
    public float currentBombTimer;
    private void Awake()
    {
        players = new List<GameObject>();
        newBomberMan.action += PickNewPlayerToCarryTheBomb;
        // newBomberManChanged += AttachBombToPlayer(0);
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        newBomberMan.action.Invoke();
        currentBombTimer = bombTimer+Time.time;

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            newBomberMan.action.Invoke();
        timer = currentBombTimer - Time.time;

        if (timer < BombClibDuration && audioSource.isPlaying==false) 
            audioSource.PlayOneShot(BombSound);
        if (timer <= 0)
        { 
            KillThePlayer();
            newBomberMan.action.Invoke();
            currentBombTimer = bombTimer + Time.time;
        }

    }
    public void PickNewPlayerToCarryTheBomb()
    {
        int x = Random.Range(0, players.Count);
        if (players[x].activeSelf == false) PickNewPlayerToCarryTheBomb();
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].activeSelf)
            {
                players[i].GetComponent<PlayerHasBomb>().HasBomb = false;
                players[i].GetComponent<PlayerHasBomb>().BombPrefab.SetActive(false);
            }
        }
        players[x].GetComponent<PlayerHasBomb>().HasBomb = true;
        players[x].GetComponent<PlayerHasBomb>().BombPrefab.SetActive( true);
    }
    public static void AttachBombToPlayer(int val)
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].activeSelf)
            {
                players[i].GetComponent<PlayerHasBomb>().HasBomb = false;
                players[i].GetComponent<PlayerHasBomb>().BombPrefab.SetActive(false);
            }
        }
        players[val].GetComponent<PlayerHasBomb>().HasBomb = true;
        players[val].GetComponent<PlayerHasBomb>().BombPrefab.SetActive(true);
    }
    private void OnDisable()
    {
        newBomberMan.action -= PickNewPlayerToCarryTheBomb;
    }

    public void KillThePlayer()
    {
        Debug.Log("nember of Players before removeing " + players.Count);
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].activeSelf)
            {
                if (players[i].GetComponent<PlayerHasBomb>().HasBomb == true)
                {
                    players.Remove(players[i]);
                    players[i].GetComponent<PlayerHasBomb>().HasBomb=false;
                    players[i].SetActive(false);
                    if (players[i].tag == "MainPlayer") Blocker.SetActive(true);
                    Debug.Log("the removed player " + players[i].name);
                };
            }
        } 
        for (int i = 0; i < players.Count; i++)
        {
             Debug.Log(players[i].name);
            players[i].GetComponent<PlayerHasBomb>().HasBomb = false;
        } 
    }

}
