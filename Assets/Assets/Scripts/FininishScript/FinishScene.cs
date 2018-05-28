using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Player")
        {
            GameObject.Find("Gameplay Controller").GetComponent<GamePlayController>().PlayerFinish();
        }
    }
}
