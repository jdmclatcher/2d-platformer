using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour {

	public int startingLives;
	private int lifeCounter;

	private Text theText;

	public GameObject gameOverScreen;

	public PlayerController player;

	public string mainMenu;

	public float waitAfterGameOver;

	// Use this for initialization
	void Start () {
		theText = GetComponent<Text> ();

		lifeCounter = startingLives;

		player = FindObjectOfType<PlayerController> ();

		//print(gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
		if (lifeCounter < 1) 
		{
			gameOverScreen.SetActive (true);
			player.gameObject.SetActive (false);
		}

		theText.text = "x " + lifeCounter;

		if (gameOverScreen.activeSelf) 
		{
			waitAfterGameOver -= Time.deltaTime;
		}

		if (waitAfterGameOver < 1) 
		{
            SceneManager.LoadScene (mainMenu);
		}
	}

	public void GiveLife()
	{
		lifeCounter++;
	}

	public void TakeLife()
	{
		lifeCounter--;
	}



}
