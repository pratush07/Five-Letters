using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class mainmenucode : MonoBehaviour {

	public GameObject newbarprefab;
	public GameObject menubuttonprefab;
	public GameObject playbuttonprefab;
	public GameObject settings;
	public GameObject removeaddbuttonprefab;

	public bool newbarselected;
	public Animator animator;
	//new postions
	public GameObject newbarprefabnewpos;
	public GameObject newmenubuttonprefabpos;
	public GameObject newplaybuttonprefabpo;
	public GameObject newremoveaddbuttonprefabpos;
	public Text bestscore;
	private GameObject newbarpos;
	private GameObject menubarpos;

	public GoogleAnalyticsV3 gog;
	// Use this for initialization
	void Start () {
		newbarselected = false;
	//	newbarpos.transform.position = newbarprefab.transform.position;
		//menubarpos.transform.position = menubuttonprefab.transform.position;
		animator = gameObject.GetComponent<Animator>();

		bestscore.text = PlayerPrefs.GetInt ("PlayerScore").ToString();
		
		if (GoogleAnalyticsV3.instance)
			GoogleAnalyticsV3.instance.LogScreen("Main Menu");
	}

	public void settingbutton()
	{
		Application.LoadLevel ("setting");

	}

	public void removeaddbutton()
	{
		//put code for removeadd and connect

	}


	public void playbutton()
	{

		Application.LoadLevel ("newtestgame");
	}

	public void achivementbutton()
	{
		Application.LoadLevel ("achivement");
	}

	public void statsbutton()
	{
		Application.LoadLevel ("stats");
	}

	public void dictionarybutton()
	{

		// point to ur website for the dictionary learning
		Application.OpenURL("http://www.google.com");
	}

	public void settingscenebutton()
	{

		Application.LoadLevel ("setting");
	}

	// Update is called once per frame
	void Update ()
	{


	
	}
}
