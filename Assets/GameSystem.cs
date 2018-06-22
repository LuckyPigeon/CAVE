using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{

    
	public void GameStart() // スタートボタンを押したら実行する
    {
		SceneManager.LoadScene("CAVE");
    }

	public void GameEnd() // ゲーム終了ボタンを押したら実行する
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
		// Application.OpenURL("http://www.yahoo.co.jp/");
#else
		Application.Quit();
#endif
    }
}


