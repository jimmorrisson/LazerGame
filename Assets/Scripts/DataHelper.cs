using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;

public class DataHelper : MonoBehaviour 
{
	public static DataHelper Instance{ get; set; }
	public BitArray UnlockedLevel{ get; set; }
	public int CurrentLevel{ get; set; }
	public List<Level> levels = new List<Level>();

	void Start () 
	{
		Instance = this;

		DontDestroyOnLoad (gameObject);

		//Load the previous scene
		Load();

		//Load Scene
		EditorSceneManager.LoadScene("MainMenuScene");
	}

	public void Save()
	{
		string saveString = "";
		for (int i = 0; i < UnlockedLevel.Count; i++) 
		{
			saveString += UnlockedLevel.Get (i).ToString();
		}
		PlayerPrefs.SetString ("saveString", saveString);
	}

	public void Load()
	{
		string loadString = PlayerPrefs.GetString ("saveString");
		int i = 0;

		foreach (char c in loadString)
		{
			if (c == 0) {
				UnlockedLevel.Set (0, false);
			} else {
				UnlockedLevel.Set (i, true);
			}
			i++;	
		}
	}
}
