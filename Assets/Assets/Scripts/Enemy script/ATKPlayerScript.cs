using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATKPlayerScript : MonoBehaviour {
    protected Animator animator;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    void Start () {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Player" && !Input.GetKey(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
            Destroy(target.gameObject, 1);
        }
    }
}
