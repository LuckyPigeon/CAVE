using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStartUIManager : MonoBehaviour {
	#region Private variable defination
	private AudioSource GameAudio; // Reference to Audio Componenet
	private bool newValue; // The term of the game
	#endregion

	#region Public variable defination

	#endregion

	public void Start(){
		GameAudio = GetComponent<AudioSource>(); // Get the audio source component in the game object
	}

	#region Game Start button function
	public void GameStart(){
		if (newValue == true) {
			SceneManager.LoadScene ("CAVE");
		} else {
			Debug.Log ("You need to read the Terms");
		}
	}
	#endregion

	#region Back button on start menu
	public void GameBack(){
		Debug.Log("BACK!"); // Quit the Menu
		Application.Quit();
	}
	#endregion

	#region Turn the music on or off
	public void MusicSwitch(){
		if (GameAudio.mute == true) {
			GameAudio.mute = false;
		} else {
			GameAudio.mute = true;
		}
	}
	#endregion

	#region Terms
	public void Terms(bool check){
		newValue = check;
	}
	#endregion
}
