using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

    int currency;
    int hp;
    int wave;

    public Player(int currency, int hp)
    {
        this.currency = currency;
        this.hp = hp;
    }

    public int GetHp()
    {
        return this.hp;
    }

    public int GetCurrency()
    {
        return this.currency;
    }

    public void SubCurrency(int amount)
    {
        this.currency -= amount;
    }
}
