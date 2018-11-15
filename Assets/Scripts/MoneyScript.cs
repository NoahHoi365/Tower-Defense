using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyScript : MonoBehaviour {

    public TextMeshProUGUI hpText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI waveText;
    Player player;
    int currency;
    int hp;
    int wave;
        
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<GameManagerScript>().GetPlayer();
	}
	
	// Update is called once per frame
	void Update ()
    {
        currency = player.GetCurrency();
        hpText.text = player.GetHp().ToString();
        moneyText.text = currency.ToString();
        waveText.text = player.GetWave().ToString();
    }

    public void EnemyHasReachedEnd()
    {
        player.SubHp(1);
    }
}
