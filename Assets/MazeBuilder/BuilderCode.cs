using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System;


public class BuilderCode : MonoBehaviour
{
	#region Private variable defination
	private string map;
	#endregion

	#region Public variable defination
    public TextAsset mapFile;
    public GameObject floor;
    public GameObject wall;
    public float scale_rate = 1.0f;
	#endregion

	#region initial
    void Start () {
		int mapIndex = UnityEngine.Random.Range (1, 10);
		string filequery = "./Assets/MazeBuilder/MAP/Map" + mapIndex + ".txt";
		StreamReader sr = new StreamReader(filequery, Encoding.Default);
		string a = sr.ReadToEnd();
		sr.Close ();
		Console.ReadLine ();
        // map = mapFile.text; //讀取文字檔中的文字
		map = a;
		Build ();
	}
	#endregion

	#region build maze
    public void Build()
    {
		int wallIndex = UnityEngine.Random.Range (1, 7);
		int keyIndex = UnityEngine.Random.Range(1, 31), appIndex = UnityEngine.Random.Range(1, 31), imgIndex = UnityEngine.Random.Range(1, 31), setpos = 0;
		float x = 0f, y = 0f, z = 0f; // init x, y, z coordinate

        for(int i = 0; i < map.Length; i++)
        {
            Vector3 pos = new Vector3(x, y, z); // Three dimension vector
            if(map[i] == '!') // If !, then scale + 1, which means at the z coordinate, will add a block toward top
            {
				x = 0f; // go back to position (0, 0)
                z += scale_rate; // scale_rate = 1
                continue;
            }
			else //通道 or 牆壁
            {
                if (map[i] != '_') // means empty and do not generate anything
                {
                    if (map[i] != '0') 
					{
						#region choose key, apple and icon's position
						setpos += 1;
						if (keyIndex == setpos) {
							keyscript.xtmp = x;
							keyscript.ztmp = z;
						} else if (appIndex == setpos) {
							AppleScript.xtmp = x;
							AppleScript.ztmp = z;
						} else if (imgIndex == setpos) {
							mainscript.xtmp = x;
							mainscript.ytmp = y;
							mainscript.ztmp = z;
						}
						#endregion
						
						#region floor
                        GameObject new_floor = Instantiate(floor, pos + new Vector3(0, scale_rate * -0.2f, 0), transform.rotation); //做平移並產生物件
                        new_floor.transform.localScale *= scale_rate; //改變物件的縮放

						if(imgIndex == setpos){
							new_floor.GetComponent<Renderer>().material.mainTexture = Resources.Load<Texture>("Icon");
						}else{
							new_floor.GetComponent<Renderer>().material.mainTexture = Resources.Load<Texture>("Floor");
						}
						new_floor.transform.parent = this.transform; //更改物件的富物件為此物件(Maze Builder)
						#endregion
                    }
                    
					i = ++i == map.Length ? i : i++; // boarder

                   	if (map[i] != '0')
                   	{
						#region ceil
                       	GameObject new_ceiling = Instantiate(floor, pos + new Vector3(0, scale_rate * 2.2f, 0), transform.rotation);
                       	new_ceiling.transform.localScale *= scale_rate;
						new_ceiling.GetComponent<Renderer>().material.mainTexture = Resources.Load<Texture>("Floor");
                       	new_ceiling.transform.parent = this.transform;
						#endregion
                   	}

                   	i++;

                    for (int j = 0; j < 4; j++)
                    {
						#region cube movement for four directions
                        Vector3 posp = new Vector3(0, scale_rate, 0);
						if (j == 0) {
							posp += new Vector3(0, 0, scale_rate * 0.4f);
						}else if (j == 1) {
							posp += new Vector3(scale_rate * 0.4f, 0, 0);
						}else if (j == 2) {
							posp += new Vector3(0, 0, scale_rate * -0.4f);
						}else if (j == 3) {
							posp += new Vector3(scale_rate * -0.4f, 0, 0);
						}
						#endregion

                        if (map[i] != '0')
                        {
							#region wall
                            GameObject new_wall = Instantiate(wall, pos + posp, transform.rotation * Quaternion.Euler(0, 90*j, 0)); //Quaternion.Euler()用來旋轉牆壁
                            new_wall.transform.localScale *= scale_rate;
							new_wall.GetComponent<Renderer>().material.mainTexture = Resources.Load<Texture>("back_" + wallIndex);
                            new_wall.transform.parent = this.transform;
							#endregion
                        }

						if (j != 3) {
							i++;
						}
                    }
                }
            }

            x += scale_rate;
        }
    }
	#endregion
}
