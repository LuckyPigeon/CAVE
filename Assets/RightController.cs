using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class RightController : MonoBehaviour {


	SteamVR_TrackedObject trackedObj;
	SteamVR_Controller.Device device;

	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
	}

	void Update () {
		device = SteamVR_Controller.Input ((int)trackedObj.index);
		#region Trigger
		if (device.GetTouch (SteamVR_Controller.ButtonMask.Trigger)) { // Trigger
			Debug.Log ("按了Trigger");
			keyscript.keytrigger = true;
			doorscript.doortrigger = true;
		}
		#endregion

		#region TouchPad
		if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad)) { // TouchPad
			Debug.Log("按了TouchPad");
		}
		#endregion

		#region Grip
		if (device.GetTouch (SteamVR_Controller.ButtonMask.Grip)) {// Grip
			Debug.Log ("按了Grip");
			mainscript.backpackgrip = true;
		}
		#endregion
	}
}