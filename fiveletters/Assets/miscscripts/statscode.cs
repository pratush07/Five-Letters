using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class statscode : MonoBehaviour {
	public Text totaltime;
	public Text gameplayed;
	public Text bestscore;
	public Text wordcount;
	// Use this for initialization
	void Start () {
	
	}


	public void backtomain()
	{
		Application.LoadLevel ("main");
	}

	public void allgameatats()
	{

		// write a code to show all the game stats to user
	}

	public void lastgamestats()
	{
		// write a code to show current game stats

	}

	public void calctime()
	{
		int time = PlayerPrefs.GetInt ("playtimesec");
		int timesec = time % 60;
		int timemin = time / 60;
		int timehr = time / 3600;

		 totaltime.text= (timehr+" hours "+timemin+" minutes "+timesec+" seconds ").ToString();
	}

	public void gamesplaycount()
	{
		gameplayed.text = PlayerPrefs.GetInt ("gamesplayed").ToString();
	}

	public void hscore()
	{
		bestscore.text = PlayerPrefs.GetInt ("PlayerScore").ToString();
	}
	public void wordsmade()
	{
		wordcount.text = PlayerPrefs.GetInt ("wordscount").ToString();
	}
	// Update is called once per frame
	void Update ()
	{
		calctime ();
		gamesplaycount ();
		hscore ();
		wordsmade ();
	}
}
