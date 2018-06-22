using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyscript : MonoBehaviour {
	#region Private variable defination

	#endregion

	#region Public variable defination
	public bool inTrigger;
	public Vector3 pos;
	public static float xtmp = 0, ztmp = 0;
	public static bool keytrigger = false;
	#endregion

	void Start(){
		/*
		 * if(mainscript.doorkeys[0] || mainscript.doorkeys[1] || mainscript.doorkeys[2])
		 * this.gameObject.SetActive(false);
		 */
		Debug.Log("setactive");
	}
	void Update()
	{
		if (inTrigger)
		{
			if (Input.GetKeyDown(KeyCode.E) || keytrigger) // Input.GetKeyDown(KeyCode.E) -> origin, keytrigger -> after
			{
				doorscript.doorKey = true;
				Destroy(this.gameObject);
			}
		}

		if ((xtmp != 0) && (ztmp != 0)) {
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

	#region Set key position
	public void setpos(){
		pos = new Vector3 (xtmp, 0.165f, ztmp);
		transform.position = pos; 
	}
	#endregion

	#region Print key state
	void OnGUI()
	{
		if (inTrigger)
		{
			GUI.Box(new Rect(0, 60, 200, 25), "Press E to take key");
		}
	}
	#endregion
}
