using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour {
	public bool inTrigger;

	void OnTriggerEnter(Collider other)
	{
		inTrigger = true;
	}

	void OnTriggerExit(Collider other)
	{
		inTrigger = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (inTrigger)
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				mainscript.app = true;
				Destroy(this.gameObject);
			}
		}
		
	}

	void OnGUI()
	{
		if (inTrigger)
		{
			GUI.Box(new Rect(0, 60, 200, 25), "Press E to take apple");
		}
	}
}
