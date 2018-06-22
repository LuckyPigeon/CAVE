using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainscript : MonoBehaviour {
	#region Private variable defination
	private int health; // Player's life
	private int damage; // Cost of one punch
	private bool backpack_trigger = false;
	#endregion

	#region Public variable defination
	public GameObject Key; // Occurred icon then key object will be activate
	public GameObject backpack; // backpack switch
    public int Health;
	public static int healthAPI; // health reference
	/*
	 * app for apple using or not, damage for get damage or not, button for some button,
	 * appstate for using apple or not
	 */
	public static bool app = false, dam, button; 

	public static bool[] doorkeys = new bool[3]{ // Door keys array, get all, get out
		false , false, false
	};
	public static bool charwin;
	public static int appcount = 0;
	public static float xtmp = 0, ytmp = 0, ztmp = 0; // Icon position アィコンの場所
	#endregion

	void Start()
	{
    	app = false;
		dam = false;
		charwin = false;
		button = false;
		health = 100;
		damage = 15;
	}

	void Update()
	{
		healthAPI = health;
		#region apple and damage function
		if (!app && appcount + 1 > 0) {
			getapple ();
			if (appcount > 0) {
				app = true;
			}
		}else if (dam) {
			getdamage ();
			dam = false;
		}
		#endregion

		#region health init
		if (health > 100) {
			health = 100;
		}else if (health <= 0) {
			Application.Quit ();
			Debug.Log ("Game Over!!!");
			SceneManager.LoadScene ("Start");
		}
		#endregion

		#region backpack switch
		if (Input.GetKeyDown (KeyCode.I)) {
			if (backpack_trigger) {
				backpack_trigger = false;
				backpack.SetActive (backpack_trigger);
			} else {
				backpack_trigger = true;
				backpack.SetActive (backpack_trigger);
			}
		}
		#endregion

		/*
		 * Upper if for diffculty playing mode, when you saw a icon, then you can start to find a key, I think
		 * this mode can be our advertising method.
		 * Lower if is means when player stand on a specific place after open a door, then you can jump to 
		 * next level, but right now, we use door open to judge if player win or not.
		 * if (transform.position.x == xtmp && transform.position.y == ytmp && transform.position.z == ztmp) {
		 *	Key.SetActive (true);
		 * } else if (transform.position.z == 14) {
		 *	charwin = true;
		 * }
		 */
	}

	#region Player get damage
	void getdamage(){
		health -= damage;
        Health = health;
	}
	#endregion

	#region Player add health
	void getapple(){
	    health += 15;
	}
	#endregion

	#region Print player state
	void OnGUI(){
		if (doorkeys [0]) { // & doorkeys [1] & doorkeys [2]) 
			GUI.Box (new Rect (0, 60, 200, 25), "You escaped!");
		}
		
		if (health <= 0) {
			GUI.Box (new Rect (0, 60, 200, 25), "GameOver!!!");
		}

		/*
		 * A game level for more difficult
		 * if (transform.position.z == 15 && (!doorkeys[0] || doorkeys[1] || doorkeys[2])){
		 * GUI.Box (new Rect(0, 60, 200, 25), "A keys has showed up, go and get it!");
		 * }
		 */
	}
	#endregion

	/*  
	 * 
	 * public void SetState(string mode, Transform obj = null)
	 * {
	 * 	if (mode == "Dead") {
	 * 		Move.velocity = Vector3.zero;
	 * 		Move.animator.SetFloat ("Speed", 0f);
	 *		Application.Quit ();
	 *  }
	 * }
	 */
}
