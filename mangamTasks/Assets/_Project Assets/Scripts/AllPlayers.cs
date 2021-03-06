using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllPlayers : MonoBehaviour
{
    public GameObject mainPlayer;
    public ScriptableEvent newBomberMan;
    public static List<GameObject> players;
    public ScriptableEventWithintSO newBomberManChanged;
    public float bombTimer;
    public GameObject Blocker;
    public GameObject winningPanal;

    public AudioClip BombSound;
    public float BombClibDuration;
    AudioSource audioSource;
    public AudioSource FinalSound;
    public AudioClip WinningSound;
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
        currentBombTimer = bombTimer + Time.time;

    }
    private void Update()
    {
        timer = currentBombTimer - Time.time;

        //test Invoking event 
        if (Input.GetKeyDown(KeyCode.H))
            newBomberMan.action.Invoke();
        //play bomb sound
        if (timer < BombClibDuration && audioSource.isPlaying == false)
            audioSource.PlayOneShot(BombSound);

        //Explode Bomb when the timer is zero
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
        //Debug.Log("number " + x);
        //Debug.Log("players.Count " + players.Count);

        if (players[x].activeSelf == false /*|| players[x].GetComponent<PlayerHasBomb>().Died ==false*/) PickNewPlayerToCarryTheBomb();
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].activeSelf)
            {
                players[i].GetComponent<PlayerHasBomb>().HasBomb = false;
                players[i].GetComponent<PlayerHasBomb>().BombPrefab.SetActive(false);
            }
        }
        players[x].GetComponent<PlayerHasBomb>().HasBomb = true;
        players[x].GetComponent<PlayerHasBomb>().BombPrefab.SetActive(true);
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
        Debug.Log("---------------nember of Players Alive--------------");
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].activeSelf)
            {
                if (players[i].GetComponent<PlayerHasBomb>().HasBomb == true)
                {
                    MakeSurePlaysListNoOneHasTheBombAttached();
                    players[i].GetComponent<PlayerHasBomb>().HasBomb = false;
                    players[i].GetComponent<PlayerHasBomb>().Died = true;
                    players[i].SetActive(false);
                    players.RemoveAt(i);
                    //if (players[i].gameObject.tag == "Untagged") Blocker.SetActive(true);
                };
            }
        }
        if (mainPlayer.activeSelf == false)
        {
            Blocker.SetActive(true);
            newBomberMan.action -= PickNewPlayerToCarryTheBomb;
        }
        CheckPlayersAlive();
    }
    void MakeSurePlaysListNoOneHasTheBombAttached()
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].GetComponent<PlayerHasBomb>().HasBomb = false;
        }
    }    
    void CheckPlayersAlive()
    {
        int alivePlayer=0;
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].GetComponent<PlayerHasBomb>().Died == false) alivePlayer++;
        }
        if (alivePlayer == 1)
        {
            Debug.Log("You Have won");

            FinalSound.PlayOneShot(WinningSound);
            winningPanal.SetActive(true);
        }
       // Debug.Log("number of Players is " + alivePlayer);
    }
    //for reloading the game
    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }

}
