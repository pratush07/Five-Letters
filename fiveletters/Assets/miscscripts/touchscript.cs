using UnityEngine;
using System.Collections;

public class touchscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnMouseDown()
	{


	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonDown(0)) {
			Debug.Log ("touched");
		}


	}
}
