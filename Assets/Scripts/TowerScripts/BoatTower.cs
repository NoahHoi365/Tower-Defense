using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatTower : Tower
{ 
    void Start()
    {
        radius = 3f;
        damage = 10f;
        canPlaceOnWater = true;
        towerCost = 10;
    }

    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
