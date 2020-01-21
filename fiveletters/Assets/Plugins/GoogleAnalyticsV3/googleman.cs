using UnityEngine;
using System.Collections;

public class googleman : MonoBehaviour {
	public GoogleAnalyticsV3 googleAnalytics;
	// Use this for initialization
	void Start () {
		googleAnalytics.LogEvent("Barren Fields", "Rescue", "Dragon", 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
