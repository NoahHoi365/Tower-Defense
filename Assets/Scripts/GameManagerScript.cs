using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    bool towerAttached = false;

    private void Start()
    {
        FindObjectOfType<MouseMove2D>().towerAttachedEvent += TowerAttached;
        FindObjectOfType<TowerPlace>().towerUnattachedEvent += TowerUnattached;
    }

    public void TowerAttached()
    {
        towerAttached = true;
    }

    public void TowerUnattached()
    {
        towerAttached = false;
    }

    public bool HasTowerAttached()
    {
        return towerAttached;
    }
}
