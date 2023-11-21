using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour {

	public string[] levelTags;

	public GameObject[] locks;

	public bool[] levelUnlocked;

	public int positionSelecter;

	public float distanceBelowLock;

	public string[] levelName;

	public float moveSpeed;

	private bool isPressed;

	public bool touchMode;

	void Start ()
	{
		

		positionSelecter = PlayerPrefs.GetInt ("PlayerLevelSelectPosition");
	
		transform.position = locks [positionSelecter].transform.position + new Vector3 (0, distanceBelowLock, 0);
	}

	void Update ()
	{
		if (!isPressed) 
		{
			if (Input.GetAxis ("Horizontal") > 0.25f) 
			{
				positionSelecter += 1;
				isPressed = true;
			}
		
			if (Input.GetAxis ("Horizontal") < -0.25f) 
			{
				positionSelecter -= 1;
				isPressed = true;
			}

			if (positionSelecter >= levelTags.Length) 
			{
				positionSelecter = levelTags.Length - 1;
			}

			if (positionSelecter < 0)
				positionSelecter = 0;
		
		}

		if (isPressed) 
		{
			if (Input.GetAxis ("Horizontal") < 0.25f && Input.GetAxis ("Horizontal") > -0.25f) 
			{
				isPressed = false;
			}
		}

		transform.position = Vector3.MoveTowards (transform.position, locks [positionSelecter].transform.position + new Vector3 (0, distanceBelowLock, 0), moveSpeed * Time.deltaTime);

		if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
		{
				if(levelUnlocked[positionSelecter] && !touchMode)
				{
					PlayerPrefs.SetInt ("PlayerLevelSelectPosition", positionSelecter);
                SceneManager.LoadScene (levelName[positionSelecter]);
				}
		}
	
	
	}

}

