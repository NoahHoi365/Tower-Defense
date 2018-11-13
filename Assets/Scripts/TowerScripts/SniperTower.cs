using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperTower : Tower
{

    private void Awake()
    {
        towerCost = 10;
    }

    void Start()
    {
        radius = 3f;
        damage = 10f;
        canPlaceOnWater = false;
        towerCost = 150;
    }

    void Update()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
