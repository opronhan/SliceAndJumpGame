using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack : MonoBehaviour {
    BoxCollider2D collider;
	// Use this for initialization
	void Start () {
        collider = GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            
            collider.enabled = true;


        }
        else
        {
            collider.enabled = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Enemy")
        {
            Destroy(target.gameObject,2);
        }
    }
}
