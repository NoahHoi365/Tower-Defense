using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour {

    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponentInParent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnButtonPress()
    {

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Fly out") || animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            animator.Play("Fly in");
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Fly in") )
        {
            animator.Play("Fly out");
        }

        
    }


}
