using UnityEngine;
using System.Collections;

using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Save()
	{
		BinaryFormatter binary = new BinaryFormatter ();
		FileStream fstream = File.Create (Application.persistentDataPath + "/data.robotboy");

		SaveManager saver = new SaveManager ();
		//saver.currentLevel = ......;
		//saver.highScore[0] = .....;
		//saver.highScore[1] = .....;
		//saver.highScore[2] = .....;

		binary.Serialize (fstream, saver);
		fstream.Close ();
	}

	void Load()
	{
		if (File.Exists (Application.persistentDataPath + "/data.robotboy")) {
			BinaryFormatter binary = new BinaryFormatter ();
			FileStream fstream = File.Open (Application.persistentDataPath + "/data.robotboy", FileMode.Open);
			SaveManager saver = (SaveManager)binary.Deserialize (fstream);
			fstream.Close ();

			//Done_GameController.print........;
			//Done_GameController.print..........;
		}
	}
}

[Serializable]
class SaveManager
{
	public int currentLevel;
	public int[] highScore;
}