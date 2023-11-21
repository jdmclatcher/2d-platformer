using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelectTouch : MonoBehaviour {

	public LevelSelectManager theLevelSelectManager;

	// Use this for initialization
	void Start () {
		theLevelSelectManager = FindObjectOfType<LevelSelectManager> ();

		theLevelSelectManager.touchMode = true;
	}
	
	public void MoveLeft()
	{
		theLevelSelectManager.positionSelecter -= 1;

		if (theLevelSelectManager.positionSelecter < 0)
			theLevelSelectManager.positionSelecter = 0;
	}

	public void MoveRight()
	{
		theLevelSelectManager.positionSelecter += 1;

		if (theLevelSelectManager.positionSelecter >= theLevelSelectManager.levelTags.Length) 
		{
			theLevelSelectManager.positionSelecter = theLevelSelectManager.levelTags.Length - 1;
		}
	}

	public void LoadLevel()
	{
		PlayerPrefs.SetInt ("PlayerLevelSelectPosition", theLevelSelectManager.positionSelecter);
        SceneManager.LoadScene (theLevelSelectManager.levelName[theLevelSelectManager.positionSelecter]);
	}
}
