using UnityEngine;
using System.Collections;

public class achivementcodes : MonoBehaviour {
	
	private float fingerStartTime  = 0.0f;
	private Vector2 fingerStartPos = Vector2.zero;
	
	private bool isSwipe = false;
	private float minSwipeDist  = 50.0f;
	private float maxSwipeTime = 0.5f;

	public Transform achivementarea;
	public Transform upperpoint;
	public Transform lowerpoint;



	// Use this for initialization
	void Start () {
	
	}

	public void backtogame()
	{
		Application.LoadLevel ("main");
		
	}


	public void allachivement()
	{
		// write here the code for showing the achivement of all times
	}

	public void currentachivements()
	{

		// write the code for retrival and display of current achivements
	}

	// Update is called once per frame
	void Update () {
	// swipe code to make scrolling for vertical
		if (Input.touchCount > 0){
			
			foreach (Touch touch in Input.touches)
			{
				switch (touch.phase)
				{
				case TouchPhase.Began :
					/* this is a new touch */
					isSwipe = true;
					fingerStartTime = Time.time;
					fingerStartPos = touch.position;
					break;
					
				case TouchPhase.Canceled :
					/* The touch is being canceled */
					isSwipe = false;
					break;
					
				case TouchPhase.Ended :
					
					float gestureTime = Time.time - fingerStartTime;
					float gestureDist = (touch.position - fingerStartPos).magnitude;
					
					if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist){
						Vector2 direction = touch.position - fingerStartPos;
						Vector2 swipeType = Vector2.zero;
						
						if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
							// the swipe is horizontal:
							swipeType = Vector2.right * Mathf.Sign(direction.x);
						}else{
							// the swipe is vertical:
							swipeType = Vector2.up * Mathf.Sign(direction.y);
						}
						
						if(swipeType.x != 0.0f){
							if(swipeType.x > 0.0f){
								// MOVE RIGHT
							}else{
								// MOVE LEFT
							}
						}
						
						if(swipeType.y != 0.0f ){
							if(swipeType.y > 0.0f){
								// MOVE UP
								Debug.Log("swipe up");

								if(achivementarea.position.y < upperpoint.position.y)
								{
								achivementarea.transform.Translate(0,30,0);
								}


							}else{
								// MOVE DOWN
								Debug.Log("swipe down");
								if(achivementarea.position.y > lowerpoint.position.y + 360)
								{
								achivementarea.transform.Translate(0,-30,0);
								}
								}
						}
						
					}
					
					break;
				}
			}
	}

	}}