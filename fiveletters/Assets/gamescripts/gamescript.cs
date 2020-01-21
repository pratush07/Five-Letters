using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class gamescript : MonoBehaviour {
												
	private string[] correctstrings= new string[230];

	//get the UI image component where the display is to be done
	public Image[] s;
	public Sprite[] allsprite;
	public Sprite basesprite;
	public Sprite initialsprite;
	public Sprite pinksprite;

	public Image[] temp;			

	public Text resulttext;
	public Text scoreongameoverhud;
	public Text bestscore;
	public Text finalscore;
	public Text[] displaytext;
	public Text[] abovetext;
	public string[] placedchar;



	public Image[] aboveimage;			
	public int currentplacingpos=0;
	public int emptypos = 0;
	public int placedpos0,placedpos1,placedpos2,placedpos3;
	public Image[] selectedimages;

	public string[] result = new string[]{"","","",""};
	int pickno;
	private string pickedstring;
	//private char[] result;

	private string bigcorrect;


	//params for detecting the touch
	private RaycastHit hit; 

	private bool s1touched,s2touched,s3touched,s4touched,s5touched;


	//params related to the swap of the textures
	private int mouseclicks=0;
	private bool pressed1 = false;
	private bool pressed2 = false;
	private bool pressed3 = false;
	private bool pressed4 = false;
	private bool pressed5 = false;

	//game pausing params
	public bool gamepause;



	//buttontouch sound
	public AudioClip buttontouch;

	//game over prefab
	public GameObject gameoverprefab;
	public GameObject displayletterprefab;
	public GameObject aboveletterprefab;

	//score update params
	public static int score =0;
	public Text scoretext;
	public int lastscore = 0;
	private bool scoreupdated;


	// timer code and its params
	public float timervar = 28.0f;
	public Image timersprite;
	public Sprite[] listoftimersprites;
	private int i = 0;



	//possible result on the game over screen this text is the child of the button shown at the game over screen
	public Text gameoverresulttext;
	public Image comeoverimage;
	public bool comeover;


	// new timer sprite and its code
	public Image cooldown;
	public bool coolingDown;
	public float waitTime = 30.0f;
	public float timerspeed=0.035f;
	public static float timeremain = 1;
	private int timer,timersec=0,timermin=0,timerhr=0,stopflag;

	//
	void Awake()
	{

	}

	// Use this for initialization
	void Start () {

		//PlayerPrefs.SetInt ("playtimesec",0);	//to initialise the prefs to 0..i.e. reset
		//PlayerPrefs.SetInt ("gamesplayed",0);
		//PlayerPrefs.SetInt ("PlayerScore",0);
		//PlayerPrefs.SetInt ("wordscount",0);

		stopflag = 0;
		 timer = (int)(Time.time);
	
		comeover = true;
		currentplacingpos = 0;
		score = 0;
		emptypos = 0;
		gamepause = false;
		//displayletterprefab.SetActive(true);
		s1touched = false;
		s2touched = false;
		s3touched = false;
		s4touched = false;
		s5touched = false;

		ReadFile();

		pickingword ();	// <-----------------

		correctedstrings ();
		pressed1 = false;
		pressed2 = false;
		pressed3 = false;
		pressed4 = false;
		pressed5 = false;

		gameoverprefab.SetActive (false);

		scoretext.text = score.ToString ();
		scoreupdated = false;

	}

	public void Restart()
	{
		resetwords ();

		comeover = true;
		currentplacingpos = 0;
		emptypos = 0;
		gamepause = false;
		//displayletterprefab.SetActive(true);
		s1touched = false;
		s2touched = false;
		s3touched = false;
		s4touched = false;
		s5touched = false;
		pickingword ();	// <-----------------
		
		correctedstrings ();
		pressed1 = false;
		pressed2 = false;
		pressed3 = false;
		pressed4 = false;
		pressed5 = false;
		
		gameoverprefab.SetActive (false);
		//timeremain = 1;
		//lastscore = PlayerPrefs.GetInt("PlayerScore");
		//Debug.Log ("lastscore"+lastscore);
		scoretext.text = score.ToString ();
		scoreupdated = false;
	}


	void rotateanddisplay()
	{

		for (int i=0; i<5; i++) {
//			displaywords (s[3-i], pickedstring [i]);
			displaytext [i].text = pickedstring [3-i].ToString ();
			s[i].sprite = basesprite;
			s[i].rectTransform.localScale = new Vector2(0.65f,0.63f);
			aboveimage [i].rectTransform.localScale = new Vector2(0.63f,0.63f);

		}
		pressed1 = false;
		pressed2 = false;
		pressed3 = false;
		pressed4 = false;
		pressed5 = false;
	}

	public void ReadFile() 
	{
		TextAsset sr = Resources.Load("fiveword") as TextAsset;
		//StreamReader sr   = new StreamReader("Assets/gamescripts/fiveword.txt");

		int i = 0;
		string[] linesFromfile = sr.text.Split("\n"[0]);
		string[] temp;
		foreach (string str in linesFromfile) 
		{
			temp=str.Split(' ');
			correctstrings [i] = temp[0];
			Debug.Log("bruaahh"+correctstrings[i].Length);
			++i;
		}
	}


	void pickingword()
	{
		//first generate a random no. and then pick the no. 
		pickno = Random.Range (0, correctstrings.Length);
		//pickno = 20;


		Debug.Log (pickno);   // pick the string of that place.

		pickedstring = correctstrings [pickno];
		Debug.Log (pickedstring);   // print the picked string

		int[] tempnum = {0,1,2,3,4};
		int len = tempnum.Length-1;
		Debug.Log ("length : "+len.ToString());
		int pickpos;
		for (int i=0; i<5; i++) 
		{
			 pickpos = Random.Range (0,len);
			displaytext [i].text = pickedstring [tempnum[pickpos]].ToString ();
			for(int j=pickpos;j<4;j++)
				tempnum[j]=tempnum[j+1];
			--len;

		}

	

	}


	public void replayfunction()
	{
		gameoverprefab.SetActive (false);
		timeremain = 1;
		Application.LoadLevel ("newtestgame");


	}


	public void optionfunction()
	{
		//Debug.Log ("inside share button");
		Application.LoadLevel ("share");

	}

	public void questiomarkfunction()
	{
		Debug.Log ("inside the question mark");
		Debug.Log (comeover);

		comeover = !comeover;


	}



	public void backtogame()
	{
		Application.LoadLevel ("game");

	}

	public void boxtouched0()
	{
		temp[0].sprite = s[0].sprite;

		int soundstat = PlayerPrefs.GetInt ("soundoff");
		// button selection logic 
		if (soundstat != 1) {
			GetComponent<AudioSource> ().PlayOneShot (buttontouch, 1.0F);
		}
			if ( pressed1 ==false) {
			Debug.Log ("inside0");
			//changing the texture of the above sprites

				//aboveimage [currentplacingpos].sprite = s [0].sprite;

			//aboveimage [currentplacingpos].sprite = pinksprite;

			//aboveimage [currentplacingpos].rectTransform.localScale = new Vector2(0.75f,0.63f);

			// now change the text for the above sprite
		
			abovetext[currentplacingpos].text = displaytext[0].text;

			placedchar[0] = displaytext[0].text.ToString();

			Debug.Log(placedchar[0]);
			Debug.Log (currentplacingpos);
			currentplacingpos +=  1;	//incrementing the next placing position
	
			//s[0].sprite = initialsprite;
		
			//s[0].rectTransform.localScale = new Vector2(0.56f,0.70f);
			pressed1=true;


	     	}

		//button unselect logic

		 else {
			Debug.Log("not allowed");
	

		

		 }


		}





	public void boxtouched1()
	{

		temp[1].sprite = s[1].sprite;

		int soundstat = PlayerPrefs.GetInt ("soundoff");
		// button selection logic 
		if (soundstat != 1) {
			GetComponent<AudioSource> ().PlayOneShot (buttontouch, 1.0F);
		}
		if (pressed2 ==false) {
			Debug.Log ("inside1");
			
		//	aboveimage [currentplacingpos].sprite = s [1].sprite;
			// now change the text for the above sprite
		
			abovetext[currentplacingpos].text = displaytext[1].text;
			//aboveimage [currentplacingpos].rectTransform.localScale = new Vector2(0.75f,0.63f);
			placedchar[1] = displaytext[1].text.ToString();

			Debug.Log (currentplacingpos);
			currentplacingpos += 1;
			//s[1].sprite = initialsprite;
		//	s[1].rectTransform.localScale = new Vector2(0.56f,0.70f);
			pressed2=true;
		}


		else {
			Debug.Log("not allowed");
	
			
		}






	}


	public void boxtouched2()
	{

		temp[2].sprite = s[2].sprite;

		int soundstat = PlayerPrefs.GetInt ("soundoff");
		// button selection logic 
		if (soundstat != 1) {
			GetComponent<AudioSource> ().PlayOneShot (buttontouch, 1.0F);
		}
		if (pressed3 ==false) {
			Debug.Log ("inside2");
			
		//	aboveimage [currentplacingpos].sprite = s [2].sprite;
		//	aboveimage [currentplacingpos].rectTransform.localScale = new Vector2(0.75f,0.63f);
		
			// now change the text for the above sprite
			abovetext[currentplacingpos].text = displaytext[2].text;
			placedchar[2] = displaytext[2].text.ToString();

			Debug.Log (currentplacingpos);
		
	currentplacingpos = currentplacingpos + 1;
			
			pressed3=true;
			//s[2].sprite = initialsprite;
		//	s[2].rectTransform.localScale = new Vector2(0.56f,0.70f);
		}


	else{
			Debug.Log("not allowed");
		
			
		}




	}


	public void boxtouched3()
	{
	/*	if (s4touched == false) {
			aboveimage [currentplacingpos].sprite = s [3].sprite;
			currentplacingpos = currentplacingpos + 1;
			s4touched =true;
		}*/


		temp[3].sprite = s[3].sprite;
		int soundstat = PlayerPrefs.GetInt ("soundoff");
		// button selection logic 
		if (soundstat != 1) {
			GetComponent<AudioSource> ().PlayOneShot (buttontouch, 1.0F);
		}
		
		if (pressed4 ==false) 
		{
			Debug.Log ("inside3");
			
		//	aboveimage [currentplacingpos].sprite = s [3].sprite;
		//	aboveimage [currentplacingpos].rectTransform.localScale = new Vector2(0.75f,0.63f);

			//abovetext[currentplacingpos].text = displaytext[2].text;
		
			// now change the text for the above sprite
			abovetext[currentplacingpos].text = displaytext[3].text;
			placedchar[3] = displaytext[3].text.ToString();

			Debug.Log (currentplacingpos);
	
			currentplacingpos = currentplacingpos + 1;
			pressed4=true;
		//	s[3].sprite = initialsprite;
	//		s[3].rectTransform.localScale = new Vector2(0.56f,0.70f);
		}
		
	
		else
		{
			Debug.Log("not allowed");
		/*	for(int i=0;i<5;i++)
			{
				if(abovetext[i].text.ToString() == placedchar[3])
				{
					
		//			s[3].sprite = aboveimage[i].sprite;
		//			aboveimage[i].sprite = initialsprite;
					abovetext[i].text = null;
				
					//		s[3].rectTransform.localScale = new Vector2(0.65f,0.63f);
				//	aboveimage [currentplacingpos-1].rectTransform.localScale = new Vector2(0.63f,0.63f);
					//	break;
					//	break;
					
				}
			}*/
			
		}
		
		



		
	}

	public void boxtouched4()	//code to move from si to ci
	{
	
		temp[4].sprite = s[4].sprite;
		int soundstat = PlayerPrefs.GetInt ("soundoff");
		// button selection logic 
		if (soundstat != 1) {
			GetComponent<AudioSource> ().PlayOneShot (buttontouch, 1.0F);
		}
		if (pressed5 ==false) 
		{
			Debug.Log ("inside4");
			
		//	aboveimage [currentplacingpos].sprite = s [4].sprite;
		//	aboveimage [currentplacingpos].rectTransform.localScale = new Vector2(0.75f,0.63f);

			//abovetext[currentplacingpos].text = displaytext[2].text;
			// now change the text for the above sprite
			abovetext[currentplacingpos].text = displaytext[4].text;
			placedchar[4] = displaytext[4].text.ToString();
			
			Debug.Log (currentplacingpos);
	
			currentplacingpos = currentplacingpos + 1;
			pressed5=true;
				//	s[4].sprite = initialsprite;
	//		s[4].rectTransform.localScale = new Vector2(0.56f,0.70f);
		}
		
		else
		{
			Debug.Log("not allowed");
		

			
		}

		
		
		
		
		
	}


	//using logic of emtypos 0 and 1 only as emptypos2 and 3 need no change of the arrangement
	// and incase of fiveletter it will be 0,1,2 not 4 and 5
	// if do not understand than think of the time when u write this code.

	public void gotmainmenu()
	{
		timeremain = 1;
		Application.LoadLevel ("main");
	}

	public void gotosettings()
	{
		timeremain = 1;
		Application.LoadLevel ("setting");
	}


	void correctedstrings()
	{
		// picking the correct string for matching the answer

		bigcorrect = correctstrings[pickno];	//contains correct element/elements of the array
		Debug.Log (bigcorrect);

	}

	//causing a delay after correct answer
	IEnumerator delayafternotcorrectanswer()
	{
		yield return new WaitForSeconds (0.0f);
		//timeremain = timeremain + 0.0f;
		justtext ();
	}

	void justtext()
	{
		Debug.Log ("delay was called");
		scoreongameoverhud.text = score.ToString ();
		//gameoverprefab.SetActive (true);

		resetwords ();
		//rotateanddisplay();

	}

	//delayed restart automatic

	IEnumerator delayRestart()
	{
		yield return new WaitForSeconds (0.3f);
		timeremain = timeremain + 0.3f;
		if (timeremain > 1) {
			timeremain = 1;
		}

		Restart ();

	}


	//clearing the selected text and making the currentpos as 0
	 public void resetwords()
	{
		currentplacingpos = 0;

		for (int i=0; i<5; i++) {
			aboveimage[i].sprite = initialsprite;
			abovetext[i].text = null;
			
		}

		pressed1 = false;
		pressed2 = false;
		pressed3 = false;
		pressed4 = false;
		pressed5 = false;

	}


	public void gameoverstatsbutton()
	{
		Application.LoadLevel ("stats");
	}

	public void gameoverachivementbutton()
	{
		Application.LoadLevel ("achivement");
	}



	// Update is called once per frame
	void Update () {


		//detecting the touch and checking that which object it hits

		//now check that the current position is 4 and if yes than check for correctness
		// check the array that was filled at the time of filling the boxes
		//user selcted string



			

		if (gamepause == false) {


			string userselectedstring = "";
			if (currentplacingpos == 5) {
				Debug.Log ("full");


				for (int i=0; i<5; i++) {

					//result [i] = selectedimages [i].sprite.name;
					result[i] = abovetext[i].text.ToString();
					userselectedstring = string.Concat (userselectedstring, result [i]);

			
				}


			}
	    // possible result on the game over screen and text on the button text
			gameoverresulttext.text = bigcorrect;

			//rearrangenew();

			//check for the correctness
			//first calculate the lengh of the big correct string 
			// match the respective cases
			int bigcorrectstringlengh = bigcorrect.Length;


			
		
				
				if (userselectedstring.Equals(bigcorrect)) 
				{
					Debug.Log ("correct answer");
					resulttext.text = "Correct Answer";
					
					if(scoreupdated != true)
					{
						int wordsmade=PlayerPrefs.GetInt("wordscount");
						++wordsmade;
						PlayerPrefs.SetInt("wordscount",wordsmade);
						score = score + 1;
						scoretext.text = score.ToString();
						//scoreongameoverhud.text = score.ToString();
						scoreupdated = true;
						lastscore=PlayerPrefs.GetInt("PlayerScore");
						if(score>lastscore)
							PlayerPrefs.SetInt("PlayerScore",score);
				
					}
					
					StartCoroutine("delayRestart");
					
				}
				
				else {
			
					if(currentplacingpos ==5)
					{
						Debug.Log (" Wrong Answer");
						resulttext.text = "Wrong Answer";
						StartCoroutine("delayafternotcorrectanswer");
					}
				}


			//
			if (coolingDown == true)	//timer code
			{
			


					timeremain -= 1.0f/waitTime * timerspeed;	//<----------------------------------------------------------------------------------------
				cooldown.fillAmount = timeremain;
	
			}




			//changing the sprite of the timer and then linking with the game finish code
			if(Time.frameCount %50 == 0)
			{
				timervar = timervar - 2;
				//Debug.Log(timervar);

				if(i>-1)
				{
//				timersprite.sprite = listoftimersprites[i+1];
				i = i+1;
				}}
				
			


			

			if(cooldown.fillAmount == 0)
			{
				//StartCoroutine("delayRestart");
				if(stopflag==0)
				{
					int timesplayed = PlayerPrefs.GetInt("gamesplayed");
					++timesplayed;
					PlayerPrefs.SetInt ("gamesplayed",timesplayed);
					int timerstop=(int)Time.time;
					timer=timerstop-timer;
				
				int lastime=PlayerPrefs.GetInt("playtimesec");
					lastime+=timer;
					PlayerPrefs.SetInt("playtimesec",lastime);
					Debug.Log(lastime);

					stopflag=1;//so that this part runs only once
				}
				bestscore.text=PlayerPrefs.GetInt("PlayerScore").ToString();
				scoreongameoverhud.text=score.ToString();
				displayletterprefab.SetActive(false);
			    aboveletterprefab.SetActive(false);
			




				gameoverprefab.SetActive (true);
			
			
			
			
			}

			if (comeover == true) {
				comeoverimage.gameObject.SetActive(false);
				//comeover = !comeover;
				
				//comeover = false;
			}
			
			if (comeover == false) {
				comeoverimage.gameObject.SetActive(true);
				//comeover = !comeover;
				//comeover = true;
			}








		}//pause if



	
	}//update
}//class
