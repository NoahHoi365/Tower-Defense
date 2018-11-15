using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatTower : Tower
{

    private void Awake()
    {
        towerCost = 450;
        shootCooldown = 1.8f;
    }

    void Start()
    {
        canPlaceOnWater = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
