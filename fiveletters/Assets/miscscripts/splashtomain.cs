using UnityEngine;
using System.Collections;

public class splashtomain : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

		if (Time.frameCount == 90) {

			Application.LoadLevel("main");
		}






	}
}
