using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	public float startingTime;

	private Text theText;

	private PauseMenu thePauseMenu;

	public GameObject gameOverScreen;

	public PlayerController player;


	// Use this for initialization
	void Start () {

		theText = GetComponent<Text> ();

		thePauseMenu = FindObjectOfType<PauseMenu> ();

		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (thePauseMenu.isPaused)
			return;

		startingTime += Time.deltaTime;

        /*if (startingTime <= 0) 
		{
			gameOverScreen.SetActive (true);
			player.gameObject.SetActive (false);
		}*/


        theText.text = "" + Mathf.Round (startingTime*10)/10;

	}
}
