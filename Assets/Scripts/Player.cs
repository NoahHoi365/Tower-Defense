public class Player {

    int currency;
    int hp;
    int wave;

    public Player(int currency, int hp)
    {
        this.currency = currency;
        this.hp = hp;
        this.wave = 1;
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

    public void AddCurrency(int amount)
    {
        this.currency += amount;
    }

    public int GetWave()
    {
        return this.wave;
    }

    public void IncreaseWave()
    {
        this.wave++;
    }
}
