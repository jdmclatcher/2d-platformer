using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string startLevel;

	public string levelSelect;

	public string level1Tag;

	public string creditsLevelLoadName;

	public void NewGame()
	{
		PlayerPrefs.SetInt ("CurrentPlayerScore", 0);

		PlayerPrefs.SetInt (level1Tag, 1);

		PlayerPrefs.SetInt ("PlayerLevelSelectPosition", 0);

		SceneManager.LoadScene (startLevel);
	}

	public void LevelSelect()
	{
		PlayerPrefs.SetInt ("CurrentPlayerScore", 0);

		PlayerPrefs.SetInt (level1Tag, 1);

		if (!PlayerPrefs.HasKey ("PlayerLevelSelectPosition")) 
		{
			PlayerPrefs.SetInt ("PlayerLevelSelectPosition", 0);
		}

        SceneManager.LoadScene (levelSelect);
	}

	public void QuitGame()
	{
		//Debug.Log ("Game Exited");
		Application.Quit ();
	}

	public void CreditsLoad()
	{
        SceneManager.LoadScene (creditsLevelLoadName);
	}

}
