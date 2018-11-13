using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultTower : Tower
{

    void Start()
    {
        radius = 3f;
        damage = 10f;
        canPlaceOnWater = false;
        towerCost = 100;
    }

    void Update()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
