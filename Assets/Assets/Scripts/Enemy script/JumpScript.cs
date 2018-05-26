using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour {
    public bool grounded;
    public Transform groundcheck;
    private Rigidbody2D rb;
    protected Animator animator;
    public Vector3 jumpForce;
    public LayerMask charmask;
    // Use this for initialization
    void Start () {
        animator = gameObject.GetComponent<Animator>();
        jumpForce = new Vector3(0, 8, 0);
        rb = GetComponent<Rigidbody2D>();
        groundcheck = GameObject.Find("enemygroundcheck").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        grounded = Physics2D.OverlapCircle(groundcheck.position, 0.5f, charmask);
        animator.SetBool("Walk", true);
        jump();
   
    }
    void jump()
    {
        if (grounded)
        {
            rb.velocity = jumpForce;
        }
    }
  
}
