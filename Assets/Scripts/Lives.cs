using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour {

    public int lives = 100;
    EnemyMove enemyMove;

	// Use this for initialization
	void Start () {
        enemyMove = FindObjectOfType<EnemyMove>();
        enemyMove.EndOfPathEvent += LifeDecrease;

	}
	
	// Update is called once per frame
	void Update () {
        print(lives);
	}

    void LifeDecrease()
    {
        lives--;
    }
}
