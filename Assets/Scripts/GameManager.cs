using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public static GameManager Instance{ get; set; }

	private Level CurrentLevel;

	public int Gold { get; set; }
	public GameObject turretContainer;
	public Text currentLevelIndex;
	public Text goldAmountText;


	void Start()
	{
		Instance = this;
		CurrentLevel = DataHelper.Instance.levels [DataHelper.Instance.CurrentLevel];
		Gold += CurrentLevel.StartingGold;

		//Game UI
		currentLevelIndex.text = "Current Level: " + DataHelper.Instance.CurrentLevel.ToString ();

		UnlockTurrets ();
		UpdateGoldText ();
	}

	private void UnlockTurrets()
	{
		int i = 0;
		foreach (Transform t in turretContainer.transform) 
		{
			bool activeButton = ((CurrentLevel.UnlockedTowers) & (1 << i)) != 0;
			//Debug.Log (activeButton);
			t.GetComponent<Button> ().interactable = activeButton;
			i++;
		}
	}

	public void ToMenu()
	{
		SceneManager.LoadScene ("MainMenuScene");
	}

	public void UpdateGoldText()
	{
		goldAmountText.text = Gold.ToString ();
	}
}
