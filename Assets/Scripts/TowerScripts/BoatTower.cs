using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatTower : Tower
{ 
    void Reset()
    {
        this.radius = 3f;
        this.damage = 10f;
        this.canPlaceOnWater = true;
    }

    void Update()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
