using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyScript : MonoBehaviour {

    public TextMeshProUGUI hpText;
    public TextMeshProUGUI moneyText;
    Player player;
    int currency;
    int hp;
        
	// Use this for initialization
	void Start () {
        FindObjectOfType<EnemyMove>().endOfPathEvent += EnemyHasReachedEnd;
        player = FindObjectOfType<GameManagerScript>().GetPlayer();
        hp = player.GetHp();
	}
	
	// Update is called once per frame
	void Update ()
    {
        currency = player.GetCurrency();
        hpText.text = hp.ToString();
        moneyText.text = currency.ToString();
        print(currency);
    }

    public void EnemyHasReachedEnd()
    {
        print("Lives --");
        hp--;
    }
}
