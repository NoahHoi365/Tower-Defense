using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatTower : Tower
{

    private void Awake()
    {
        towerCost = -1;
    }

    void Start()
    {
        radius = 3f;
        damage = 10f;
        canPlaceOnWater = true;
    }

    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
