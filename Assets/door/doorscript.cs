using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class doorscript : MonoBehaviour {
	#region Private variable defination
	private int keyindex = 0;
	private System.DateTime timeover = new System.DateTime (3);
	private System.DateTime nulltime = new System.DateTime (0);
	#endregion

	#region Public variable defination
	public static bool doorKey;
	public bool open;
	public bool close;
	public bool inTrigger;
	public AudioSource dooropen;
	public AudioSource doorclose;
	public static bool doortrigger = false;
	#endregion

	void Update()
	{
		if (inTrigger)
		{
			if (close)
			{
				if (doorKey)
				{
					if (Input.GetKeyDown(KeyCode.E) || doortrigger)
					{
						System.DateTime nowtime = System.DateTime.Now;
						open = true;
						close = false;
						dooropen.Play ();
						mainscript.doorkeys [keyindex] = true;
						for (int i = 0; i < mainscript.doorkeys.Length; i++) {
							if (i == 0) {
								keyindex += 1;
							}

							if (mainscript.doorkeys [i] == true) {
								keyindex += 1;
							}
						}
						if (mainscript.doorkeys [0]) { // && mainscript.doorkeys [1] && mainscript.doorkeys [2] && open) {
							Wait ();
							SceneManager.LoadScene ("Start"); // Win menu hasn't done yet, so use Start as subsitution
						} else if (open) {
							SceneManager.LoadScene ("CAVE");
						}
					}
				}
			}
			else
			{
				if (Input.GetKeyDown(KeyCode.E) || doortrigger)
				{
					close = true;
					open = false;
					doorclose.Play ();
				}
			}
		}

		if (open)
		{
			var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, -90.0f, 0.0f), Time.deltaTime * 200);
			transform.rotation = newRot;

		}
		else
		{
			var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 0.0f, 0.0f), Time.deltaTime * 200);
			transform.rotation = newRot;
		}
	}

	#region Object Collider enter trigger
	void OnTriggerEnter(Collider other)
	{
		inTrigger = true;
	}
	#endregion

	#region Object Collider exit trigger
	void OnTriggerExit(Collider other)
	{
		inTrigger = false;
	}
	#endregion

	#region Make system wait for 3 seconds
	IEnumerator Wait(){
		yield return new WaitForSeconds (3);
	}
	#endregion

	#region Print door state
	void OnGUI()
	{
		if (inTrigger)
		{
			if (open)
			{
				GUI.Box(new Rect(0, 0, 200, 25), "Press E to close");
			}
			else
			{
				if (doorKey)
				{
					GUI.Box(new Rect(0, 0, 200, 25), "Press E to open");
				}
				else
				{
					GUI.Box(new Rect(0, 0, 200, 25), "Need a key!");
				}
			}
		}

		switch (keyindex) {
		case 0:
			GUI.Box (new Rect (0, 0, 200, 25), "第一關");
			break;
		case 1:
			GUI.Box (new Rect (0, 0, 200, 25), "第二關");
			break;
		case 2:
			GUI.Box (new Rect (0, 0, 200, 25), "第三關");
			break;
		}
	}
	#endregion
}
