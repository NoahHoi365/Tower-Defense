using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour {

    Animator animator;
    
	void Start () {
        animator = GetComponentInParent<Animator>();
	}

    public void OnButtonPress()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Fly out") || animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) {
            animator.Play("Fly in");
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Fly in")) {
            animator.Play("Fly out");
        }
    }

    public void OnTowerPress(GameObject obj)
    {
        bool towerAttached = FindObjectOfType<GameManagerScript>().HasTowerAttached();
        if (!towerAttached) {
            GameObject temp = Instantiate(obj);
            temp.SetActive(false);
            temp.transform.parent = null;
            if (FindObjectOfType<Player>().GetCurrency() > temp.GetComponent<Tower>().GetTowerCost()) {
                FindObjectOfType<Player>().SubCurrency(temp.GetComponent<Tower>().GetTowerCost());
                print(temp.GetComponent<Tower>().GetTowerCost());
                print(temp.name);
                temp.SetActive(true);
            } else {
                Destroy(temp);
            }
        }
    }
}
