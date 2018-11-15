using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    bool towerAttached = false;
    Player player;

    public int playerCurrency, playerHp;

    private void Awake()
    {
        player = new Player(playerCurrency, playerHp);
    }

    private void Start()
    {
        player.playerDeathEvent += PlayerDied;
    }

    public void TowerAttached()
    {
        towerAttached = true;
    }

    public void TowerUnattached()
    {
        towerAttached = false;
    }

    public bool HasTowerAttached()
    {
        return towerAttached;
    }

    public Player GetPlayer()
    {
        return player;
    }

    public void PlayerDied()
    {
        FindObjectOfType<EventScript>().Menu();
    }
}
