﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienTower : Tower {

	void Start () {
        radius = 3f;
        damage = 10f;
        canPlaceOnWater = false;
        towerCost = 10;
    }
	
	void Update () {
		
	}

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
