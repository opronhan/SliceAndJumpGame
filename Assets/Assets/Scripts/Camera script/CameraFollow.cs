using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    private Transform player;
    public float minX, maxX;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform; // toa do nguoi choi
	}
	
	// Update is called once per frame
	void Update () {
		if(player != null) // neu nguoi choi co trong camera thi
        {
            Vector3 temp = transform.position;
            temp.x = player.position.x;
            if(temp.x < minX)
            {
                temp.x = minX;
            }
            if(temp.x > maxX)
            {
                temp.x = maxX;
            }
            transform.position = temp;
        }
	}
}
