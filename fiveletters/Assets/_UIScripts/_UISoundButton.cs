using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class _UISoundButton : MonoBehaviour {
	public static _UISoundButton instance;
	public Button onButton;
	public Button offButton;

	void Awake () 
	{
		instance = this;
	}

	//This will replace icon image with sound ON
	public void SetSoundOnImage()
	{
		onButton.gameObject.SetActive (true);
		offButton.gameObject.SetActive (false);
	}
	//This will replace icon image with sound OFF
	public void SetSoundOffImage()
	{
		onButton.gameObject.SetActive (false);
		offButton.gameObject.SetActive (true);
	}
}
