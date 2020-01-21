using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class _HudManager : MonoBehaviour 
{
	//this is class is used to manage the hud ui objects.
	public Text hudScoreText; 
	public Text gameOverScoreText;
	public Text gameOverBestScoreText;
	public GameObject rewardVideo;
	public GameObject gameOver;

	public static _HudManager instance; 

	void Awake()
	{
		instance = this;
	}

	//Enable or disable reward video button and text
	public void EnableRewardVideo(bool _enable)
	{
		rewardVideo.SetActive (_enable);
	}

	//Set text of hud score (the one shown during gameplay
	public void SetHudScore(int _score)
	{
		if (hudScoreText.text != _score.ToString())
		{
			hudScoreText.text = _score.ToString();
		}
	}

	//Set text of Gameover score 
	public void SetGameOverScore(int _score)
	{
		if (gameOverScoreText.text != _score.ToString())
		{
			gameOverScoreText.text = _score.ToString();
		}
	}

	//Set text of Gameover best score 
	public void SetGameOverBestScore(int _score)
	{
		if (gameOverBestScoreText.text != _score.ToString())
		{
			gameOverBestScoreText.text = _score.ToString();
		}
	}

	public void ShowGameOverMenu()
	{
		gameOver.SetActive (true);
	}

}
