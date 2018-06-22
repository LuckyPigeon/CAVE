using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackgroundMusicPitchOnStart : MonoBehaviour {

	public float pitch; //寫改成的pitch值

	void Start()
	{
		//取得背景音樂
		AudioSource source = GameObject.FindGameObjectWithTag ("Background Music").GetComponent<AudioSource> ();
		source.Stop();  //暫停音樂
		source.pitch = pitch;  //改變pitch
		source.Play();  //開始音樂
	}
}
