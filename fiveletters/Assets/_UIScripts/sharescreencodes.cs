using UnityEngine;
using System.Collections;

public class sharescreencodes : MonoBehaviour {

	public Transform sharebg;
	public Transform leftendpoint;
	public Transform rightendpoint;

	// Use this for initialization
	void Start () {
	
	}


	public void sharereturn()
	{
		Application.LoadLevel ("game");
	}

	public void sharefunction()
	{
		// write a code for sharing the pics on FB and TW

	}

	public void moverightfunction()
	{
		if (sharebg.transform.position.x < rightendpoint.transform.position.x) {
			sharebg.Translate (100.0f, 0, 0);
			
		} else {	//sharebg.Translate (-24f, 0, 0);
			
		}





	}

	public void moveleftfunction()
	{
		if (sharebg.transform.position.x > leftendpoint.transform.position.x) {
			sharebg.Translate (-100.0f, 0, 0);

		} else {	//sharebg.Translate (-24f, 0, 0);

		}
	}


	// Update is called once per frame
	void Update () {
	
	}
}
