using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    int currency;
    int hp;

    private void Start()
    {
        currency = 1000;
        hp = 10;
    }

    private void Update()
    {
        print(currency);
    }

    public int GetHp()
    {
        return hp;
    }

    public int GetCurrency()
    {
        return currency;
    }

    public void SubCurrency(int amount)
    {
        currency -= amount;
    }
}
