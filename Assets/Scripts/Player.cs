public class Player {

    int currency;
    int hp;
    int wave;

    public delegate void PlayerDeath();
    public event PlayerDeath playerDeathEvent;

    public Player(int currency, int hp)
    {
        this.currency = currency;
        this.hp = hp;
        wave = 1;
    }

    public int GetHp()
    {
        return hp;
    }

    public void SubHp(int amount)
    {
        hp -= amount;
        if(hp <= 0) {
            if(playerDeathEvent != null) {
                playerDeathEvent();
            }
        }
    }

    public int GetCurrency()
    {
        return currency;
    }

    public void SubCurrency(int amount)
    {
        currency -= amount;
    }

    public void AddCurrency(int amount)
    {
        currency += amount;
    }

    public int GetWave()
    {
        return wave;
    }

    public void IncreaseWave()
    {
        wave++;
    }
}
