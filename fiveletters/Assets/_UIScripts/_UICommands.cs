using UnityEngine;
using System.Collections;

public class _UICommands : MonoBehaviour {
	//Please call the actual functions from this dummy code
	
	public void Play()
	{
		Debug.Log ("Play");
	}

	public void HighScore()
	{
		Debug.Log ("HighScore");
	}

	public void Rate()
	{
		Debug.Log ("Rate");
	}

	public void RemoveAds()
	{
		Debug.Log ("RemoveAds");
	}

	public void RestoreIAP()
	{
		Debug.Log ("RestoreIAP");
	}

	public void TurnSoundON()
	{
		Debug.Log ("TurnSoundON");
		_UISoundButton.instance.SetSoundOnImage ();

	}
	public void TurnSoundOFF()
	{
		Debug.Log ("TurnSoundOFF");
		_UISoundButton.instance.SetSoundOffImage ();
	}

	public void Pause()
	{
		Application.LoadLevel ("main");
		Debug.Log ("Pause");
	}

	public void Resume()
	{
		Debug.Log ("Resume");
	}


	public void MainMenu()
	{
		Debug.Log ("MainMenu");
	}

	public void Restart()
	{
		Application.LoadLevel ("main");
		Debug.Log ("Restart");
	}

	public void ShowRewardVideo()
	{
		Debug.Log ("ShowRewardVideo");
	}

	public void FacebookShare()
	{
		Debug.Log ("FacebookShare");
	}

	public void TweeterShare()
	{
		Debug.Log ("TweeterShare");
	}

	public void EnableRewardVideo(bool _enable)
	{
		if (_HudManager.instance != null)
			_HudManager.instance.rewardVideo.SetActive (_enable);
	}
	
	//Set text of hud score (the one shown during gameplay
	public void SetHudScore(int _score)
	{
		if (_HudManager.instance != null)
		{
			if (_HudManager.instance.hudScoreText.text != _score.ToString())
			{
			_HudManager.instance.hudScoreText.text = _score.ToString();
			}
		}
	}
	
	//Set text of Gameover score 
	public void SetGameOverScore(int _score)
	{	if (_HudManager.instance != null) 
		{
			if (_HudManager.instance.gameOverScoreText.text != _score.ToString ()) 
			{
				_HudManager.instance.gameOverScoreText.text = _score.ToString ();
			}
		}
	}
	
	//Set text of Gameover best score 
	public void SetGameOverBestScore(int _score)
	{
		if (_HudManager.instance != null)
		{
			if (_HudManager.instance.gameOverBestScoreText.text != _score.ToString())
			{
				_HudManager.instance.gameOverBestScoreText.text = _score.ToString();
			}
		}
	}
	
	public void ShowGameOverMenu()
	{		
		if (_HudManager.instance != null)
			_HudManager.instance.gameOver.SetActive (true);
	}
}
