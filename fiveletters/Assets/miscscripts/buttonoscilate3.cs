using UnityEngine;
using System.Collections;

public class buttonoscilate3 : MonoBehaviour {

	
	private float speed = 2.0f;
	
	private Vector3 startpos;

	// Use this for initialization
	void Start () {
		startpos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0,speed*Time.deltaTime,0);
		
		if (transform.position.y > startpos.y + 6) {
			speed = -speed;
			
		}
		
		
		if (transform.position.y < startpos.y - 6) {
			speed = -speed;
			
		}
	}
}
