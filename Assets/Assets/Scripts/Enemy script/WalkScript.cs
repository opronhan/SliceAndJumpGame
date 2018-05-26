using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkScript : MonoBehaviour {
    [SerializeField]
    private Transform startPos, endPos;
    private bool collision;
    public float speed = 1f;
    private Rigidbody2D rb;
    protected Animator animator;

    void Awake()
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
        ChangeDirection();
    }

    void Move()
    {
        rb.velocity = new Vector2(transform.localScale.x, 0) * speed;

    }
    void ChangeDirection()
    {
        //Neu con nhen khong va cham voi nen dat se quay nguoc ve
        collision = Physics2D.Linecast(startPos.position, endPos.position, 1 << LayerMask.NameToLayer("Ground"));
        Debug.DrawLine(startPos.position, endPos.position, Color.green);
        if (!collision)
        {
            Vector3 temp = transform.localScale;
            if (temp.x == 9.136563f) //toa do cua enemy
            {
                temp.x = -9.136563f;
            }
            else
            {
                temp.x = 9.136563f;
            }
            transform.localScale = temp;
        }
    }
}
