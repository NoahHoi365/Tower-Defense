﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyScript : MonoBehaviour {

    public TextMeshProUGUI text;
        
	// Use this for initialization
	void Start () {
        FindObjectOfType<EnemyMove>().endOfPathEvent += EnemyHasReachedEnd;

        text.text = "7666";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EnemyHasReachedEnd()
    {
        print("Lives --");
    }
}
