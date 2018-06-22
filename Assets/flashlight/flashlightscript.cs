using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightscript : MonoBehaviour {
	/*
	 * public bool Light = false;
	 * Use this for initialization
	 */
	#region Private variable defination
	private Light myLight;
	#endregion

	#region Public variable defination
	public AudioSource buttom_on;
	public AudioSource buttom_off;
	public static bool flashlightgrip = false;
	#endregion

	void Start ()
	{
		myLight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.L)||flashlightgrip) 
		{
			if (myLight.enabled == false) 
			{
				myLight.enabled = true;
				buttom_on.Play ();
			} else {
				myLight.enabled = false;
				buttom_off.Play ();
			}
		}
	}
}