﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATKPlayerScript : MonoBehaviour {
    protected Animator animator;
    private Rigidbody2D rb;
    public Transform groundcheck;
    public bool grounded;
    public AudioSource slimeAtack;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    void Start () {
        animator = gameObject.GetComponent<Animator>();
        slimeAtack = GameObject.Find("SlimeAttack").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
		
	}
    public void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Player" && !Input.GetKey(KeyCode.Space))
        {
            Destroy(target.gameObject, 1);
            StartCoroutine(playerDie());
        }
          
    }
    IEnumerator playerDie()
    {
        //This is a coroutine
        slimeAtack.Play();
        animator.SetTrigger("Attack");
        
        
        yield return new WaitForSeconds(2);    //Wait one frame

        GameObject.Find("Gameplay Controller").GetComponent<GamePlayController>().PlayerDied();
    }

}

