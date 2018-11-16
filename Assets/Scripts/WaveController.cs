﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

    public delegate void WaveCount();
    public event WaveCount waveCountEvent;

    public float startWait, spawnWait, waveWait;

    public AudioSource round;
    public GameObject enemyPrefab;
    public Transform spawnPosition;

    Player player;
    
    int spawnAmount = 5;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        player = FindObjectOfType<GameManagerScript>().GetPlayer();

        yield return new WaitForSeconds(startWait);
        while(true) {
            for(int i = 0; i < spawnAmount; i++) {
                Instantiate(enemyPrefab, spawnPosition);
                yield return new WaitForSeconds(spawnWait);
            }
            spawnAmount += 3;
            yield return new WaitForSeconds(waveWait);
            round.Play();
            player.IncreaseWave();
        }
    } 
}