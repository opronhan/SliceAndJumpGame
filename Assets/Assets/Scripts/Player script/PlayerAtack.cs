using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerAtack : MonoBehaviour {
    BoxCollider2D collider;
    public Transform groundcheck;
    public LayerMask charmask;
    public bool grounded;
    [SerializeField]
    private Text score;
    private int scorecount = 0;
    // Use this for initialization
    void Start () {
        collider = GetComponent<BoxCollider2D>();
        score = GameObject.Find("Score").GetComponent<Text>();
        groundcheck = GameObject.Find("playergroundcheck").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            
            collider.enabled = true;


        }
        else
        {
            collider.enabled = false;
        }
    }
    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundcheck.position, 0.5f, charmask);
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Enemy")
        {
            Destroy(target.gameObject,2);
            scorecount += 200;
        }
        score.text = "" + scorecount;
    }
}
