using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float hp = 10f;
    Player player;

    private void Start()
    {
        player = FindObjectOfType<GameManagerScript>().GetPlayer();
    }

    private void Update()
    {
        if (hp <= 0) {
            if(player != null)
                player.AddCurrency(10);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float amount)
    {
        hp -= amount;
    }
}
