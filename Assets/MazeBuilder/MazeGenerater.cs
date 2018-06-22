using UnityEngine;
using System.Collections;

public class MazeGenerater : MonoBehaviour
{
	private string mazetext = "", pcc = "0123";
	private string[,] mazearr = new string[11,11];
	private int put, count = 0;
	private int[] dir = new int[4];
	public int width = 11, height = 11;
	// Use this for initialization
	void Start ()
	{
		System.IO.File.WriteAllText(".\\Map.txt", "");
		Build ();
		MazeT ();
	}

	#region Build Maze text
	public void Build(){
		dir [0] = 1;
		dir [1] = -1;
		dir [2] = width;
		dir [3] = -width;
		int[] maze = new int[width * height];
		for(int i=0; i<width*height; i++) maze[i]=0;

		for(int i=0; i<width*height; i++){
			bool flag = (i % width) == 0 ? true : false;
			
			if(i<width || i>=width*height-width|| flag || i%width==width-1){
				maze[i]=1;
			} else {
				flag = (i % width % 2) == 0 ? true : false;

				bool flag1 = (i / width % 2) == 0 ? true : false;
				
				if(flag & flag1) {
					maze[i] = 1;
					while (true) 
						if(maze [put = i + dir [Random.Range (0, 1000000) % 4]] == 0)
							break;
					maze[put]=1;
				} 
			}
		}

		maze[1]=2;
		maze[width*height-2]=3;

		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {
				mazearr[i, j] = pcc [maze [count]].ToString();
				count += 1;
				// if (i % width == width - 1)
					// mazetext += "!";
			}
		}

		// System.IO.File.WriteAllText(".\\Map.txt", mazetext);
	}
	#endregion

	public void MazeT(){
		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {
				if ((i == 0) && (j == 1)) {
					mazetext += "111000";
				}
				else if (mazearr [i, j] != "1")
					mazetext += "110000";
				else {
					mazetext += "00";
					if (i != 0)
						mazetext += beside (i - 1, j);
					else if (i != width - 1)
						mazetext += beside (i + 1, j);
					else if (j != 0)
						mazetext += beside (i, j - 1);
					else if (j != height - 1)
						mazetext += beside (i, j + 1);
				}
			}

			mazetext += "!";
		}
	}

	public string beside(int w, int h){
		if (mazearr [w, h] != "1") // それが壁ならば
			return "1";
		else　//　それがチャネルならば
			return "0";
	}
}

