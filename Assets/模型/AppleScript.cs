using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour {
	#region Private variable drfination

	#endregion

	#region Public variable defination
	public bool inTrigger;
	public Vector3 pos;
	public static float xtmp = 0, ztmp = 0;
	public static bool apptrigger = false;
	#endregion

	void Update () {
		if (inTrigger)
		{
			if (Input.GetKeyDown(KeyCode.Z) || apptrigger) // Input.GetKeyDown(KeyCode.Z) -> origin, apptrigger -> after
			{
				mainscript.app = true;
				mainscript.appcount += 1;
                Destroy(this.gameObject);
			}
		}

		if((xtmp != 0) && (ztmp != 0)){
			setpos ();
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

	#region Set apple position
	public void setpos(){
		pos = transform.position;
		pos.x = xtmp;
		pos.z = ztmp;
		transform.position = pos; 
	}
	#endregion
  
	#region Print apple state
	void OnGUI()
	{
		if (inTrigger)
		{
			GUI.Box(new Rect(0, 60, 200, 25), "Press Z to take apple");
        }
	}
	#endregion
}
