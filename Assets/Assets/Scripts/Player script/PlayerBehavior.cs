using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {
    public GameObject gameGround;
    public Vector3 speed;
    protected Animator animator;
    public Vector2 movingForce;
    public Vector3 jumpForce;
    public Rigidbody2D rb;
    public Transform groundcheck;
    public LayerMask charmask;
    public bool grounded;
    // Use this for initialization
    void Start () {
        speed = new Vector3(3, 0 ,0);
        movingForce = new Vector2(10, 0);
        jumpForce = new Vector3(0, 8 ,0);
        animator = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        groundcheck = GameObject.Find("playergroundcheck").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
		//chuyển state
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Running");
            animator.SetInteger("AnimationState", 1);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Atack");
            animator.SetInteger("AnimationState", 2);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("Jump");
            animator.SetInteger("AnimationState", 4);
            jump();
        }
        else
        {
            Debug.Log("Idle");
            animator.SetInteger("AnimationState", 0);
        }
        //close
       



    }
  
    //Những hàm xử lý va chạm giữa player voi cac object
    void OnCollisionEnter2D(Collision2D target)
    {
    
    }

    void OnCollisionStay2D(Collision2D target)
    {
       
    }
    void OnCollisionExit2D(Collision2D target)
    {
       
    }

    //close

    //Các tính toán, tương tác vật lý, chúng ta sẽ đặt trong hàm này, ví dụ như AddForce, etc
    void FixedUpdate()
    {
        Vector3 localScale = transform.localScale;
        grounded = Physics2D.OverlapCircle(groundcheck.position, 0.5f, charmask);
        //Translation
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-movingForce);

            if (localScale.x > 0)
            {
                localScale.x *= -1.0f;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(movingForce);
            if (localScale.x < 0)
            {
                localScale.x *= -1.0f;
            }
        }
      
        transform.localScale = localScale;
        //close


    }
    //ham nhay
    void jump()
    {
        if (grounded)
        {
            rb.velocity = jumpForce;
        }
    }
    //close
   
   
           
       
   


}
