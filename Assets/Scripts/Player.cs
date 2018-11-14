using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

    int currency;
    int hp;

    public Player(int currency, int hp)
    {
        currency = 1000;
        hp = 10;
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
