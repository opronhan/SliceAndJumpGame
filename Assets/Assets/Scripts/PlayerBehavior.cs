using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {
    public GameObject gameGround;
    public Vector3 speed;
    protected Animator animator;
    public Vector2 movingForce;
    public Vector2 jumpForce;
    public Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        speed = new Vector3(3, 0 ,0);
        movingForce = new Vector2(10, 0);
        jumpForce = new Vector3(0, 15);
        animator = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
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
        }
        else
        {
            Debug.Log("Idle");
            animator.SetInteger("AnimationState", 0);
        }
        //close
       



    }

    //Các tính toán, tương tác vật lý, chúng ta sẽ đặt trong hàm này, ví dụ như AddForce, etc
    void FixedUpdate()
    {
        Vector3 localScale = transform.localScale;
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
        if (Input.GetKey(KeyCode.UpArrow))
        {
            
                rb.AddForce(jumpForce);
                
            
            
        }
        transform.localScale = localScale;
        //close

    }
    
            //Hàm này được gọi khi có hai đối tượng va chạm nhau.

            //Hàm này được gọi khi có hai đối tượng va chạm nhau, trong đó có 1 hoặc cả hai đối tượng là Trigger.

        }
