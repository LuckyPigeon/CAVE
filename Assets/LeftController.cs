using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class LeftController : MonoBehaviour {

	public GameObject player;

	SteamVR_TrackedObject trackedObj;
	SteamVR_Controller.Device device;

	Vector2 touchpad;

	private float sensitivityX = 1.5F;
	private Vector3 playerPos;

	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
	}

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
			//Debug.Log("按了TouchPad");

			//Read the touchpad values
			touchpad = device.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);

			// Handle movement via touchpad
			if (touchpad.y > 0.2f || touchpad.y < -0.2f) {
				// Move Forward
				player.transform.position -= player.transform.forward * Time.deltaTime * (touchpad.y * 5f);

				// Adjust height to terrain height at player positin
				playerPos = player.transform.position;
				playerPos.y = Terrain.activeTerrain.SampleHeight (player.transform.position);
				player.transform.position = playerPos;
			}

			// handle rotation via touchpad
			if (touchpad.x > 0.3f || touchpad.x < -0.3f) {
				player.transform.Rotate (0, touchpad.x * sensitivityX, 0);
			}

			Debug.Log ("Touchpad X = " + touchpad.x + " : Touchpad Y = " + touchpad.y);
		}
		#endregion

		#region Grip
		if (device.GetTouch (SteamVR_Controller.ButtonMask.Grip)) {// Grip
			Debug.Log ("按了Grip");
			flashlightscript.flashlightgrip = true;
		}
		#endregion
	}
}