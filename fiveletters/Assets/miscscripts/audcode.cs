using UnityEngine;
using System.Collections;

public class audcode : MonoBehaviour {

	private static audcode instance = null;
	public static audcode Instance {
		get { return instance; }
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void Awake() {
	if (instance != null && instance != this) {
			Debug.Log("gameobject will be destroyed");
			Destroy(this.gameObject);
		return;
	} else {
		instance = this;
	}
	DontDestroyOnLoad(this.gameObject);
}
}
