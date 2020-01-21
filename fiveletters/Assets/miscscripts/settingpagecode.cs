using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class settingpagecode : MonoBehaviour {

	public AudioSource aud;
	bool soundplay;
	public Image soundsprstat;
	public Sprite[] soundsprarray;
	int soundstat;
	// Use this for initialization
	void Start () 
	{	
		aud = GameObject.Find ("aud").GetComponent<AudioSource>();
		soundstat = PlayerPrefs.GetInt ("soundoff");
		if (soundstat == 1) 
		{
			soundplay=false;
			soundsprstat.sprite = soundsprarray [1];
		} 
		else {
			soundplay=true;
			soundsprstat.sprite = soundsprarray [0];
		}
	}

	public void backbutton()
	{
		Application.LoadLevel ("main");
	}

	public void musicfunction()
	{
		//write code for swithcing on and off music
	}

	public void soundeffects()
	{

		soundplay = !soundplay;
		if (!soundplay) {
			aud.mute = true;
			soundsprstat.sprite = soundsprarray [1];
			PlayerPrefs.SetInt("soundoff",1);
		} else {
		aud.mute = false;
			soundsprstat.sprite = soundsprarray [0];
			PlayerPrefs.SetInt("soundoff",0);
		}
	}

	public void restorepurchase()
	{
		// write a code to restore purcahses
	}


	public void removeads()
	{
		// write a code to remove adv of ur adv network
	}

	public void credits()
	{
		// write a code to show the credits

	}

	public void moregames()
	{

		//write a code to direct your user to more of your games
	}

	public void contactus()
	{
		// write code for contactus info


	}


	// Update is called once per frame
	void Update () {
	
	}
}
