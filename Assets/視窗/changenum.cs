using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changenum : MonoBehaviour
{
    void Start()
    {
		this.gameObject.SetActive (false);
    }

	void update(){
		if (Input.GetKeyDown (KeyCode.U)) {
			mainscript.app = false;
			mainscript.appcount -= 1;
		}
	}
}
