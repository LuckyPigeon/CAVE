using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class testcontrol : MonoBehaviour {


	SteamVR_TrackedObject trackedObj;
	SteamVR_Controller.Device device;
	// Use this for initialization
	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		device = SteamVR_Controller.Input ((int)trackedObj.index);
		#region Trigger
		if (device.GetTouch (SteamVR_Controller.ButtonMask.Trigger)) { // Trigger
			Debug.Log ("按了Trigger");
			AppleScript.apptrigger = true;
		}
		#endregion

		#region TouchPad
		if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad)) { // TouchPad
			Debug.Log("按了TouchPad");
		}
		#endregion

		#region Grip
		if(device.GetTouch(SteamVR_Controller.ButtonMask.Grip)) { // Grip
			Debug.Log("按了Grip");
		}
		#endregion
	}
}
