using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {
	#region Private variable defination
	private bool newValue = false; // The term of the game
	#endregion

	#region Public variable defination

	#endregion

	void Start () {
		
	}

	#region Game Start button function
	public void GameStart(){
		SceneManager.LoadScene ("CAVE");
	}
	#endregion
}
