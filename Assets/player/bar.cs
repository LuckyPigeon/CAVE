
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bar : MonoBehaviour {
	public float MaxBlood = 100;
	public float Blood=mainscript.healthAPI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		///Blood=mainscript.Health;
		Blood=mainscript.healthAPI;
		this.transform.localPosition=new Vector3((-30+30*(Blood/MaxBlood)),0.0f,0.0f);

	}
}
