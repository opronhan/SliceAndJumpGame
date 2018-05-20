using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkScript : MonoBehaviour {

    public float speed = 1f;
    private Rigidbody2D rb;
    protected Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D> ();
    }
    // Use this for initialization
    void Start () {
        animator = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        animator.SetBool("Walk", true);
        Move();
	}

    void Move()
    {
        rb.AddForce(new Vector2(transform.localScale.x, 0) * speed);
    }
}
