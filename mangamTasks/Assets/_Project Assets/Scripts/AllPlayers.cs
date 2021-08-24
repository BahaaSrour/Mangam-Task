using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPlayers : MonoBehaviour
{
    public ScriptableEvent newBomberMan;
    public static List<GameObject> players;

    public ScriptableEventWithintSO newBomberManChanged;
    private void Awake()
    {
        players = new List<GameObject>();
        newBomberMan.action += PickNewPlayerToCarryTheBomb;
       // newBomberManChanged += AttachBombToPlayer(0);
    }

    private void Start()
    {
        newBomberMan.action.Invoke();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            newBomberMan.action.Invoke();
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

}
