using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour {
	/*** Part 18 ***/
	public int startingLives;
	private int lifeCounter;

	private Text theText;
	public GameObject gameOverScreen;
	public PlayerController playerController;

	public string mainMenu;
	public float waitAfterGameOver;


	// Use this for initialization
	void Start () {
		theText = GetComponent<Text> ();
		lifeCounter = startingLives;
		playerController = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (lifeCounter == 0) {
			gameOverScreen.SetActive (true);
			playerController.gameObject.SetActive (false);
		}

		theText.text = "x " + lifeCounter;

		if (gameOverScreen.activeSelf) {
			waitAfterGameOver -= Time.deltaTime;
		}

		if (waitAfterGameOver < 0) {
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
