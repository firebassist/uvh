using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
	/*** Part 16 ***/
	public string mainMenu;

	public bool isPaused;

	public GameObject pauseMenuCanvas;

	
	// Update is called once per frame
	void Update () {
		if (isPaused) {
			pauseMenuCanvas.SetActive (true);
			Time.timeScale = 0f;
		} else {
			pauseMenuCanvas.SetActive (false);
			Time.timeScale = 1f;
		}

		if(Input.GetKeyDown (KeyCode.P)) {

			//PauseUnpause();
			isPaused = !isPaused;
		}
	}

	public void Resume() {

		isPaused = false;
	}

	public void QuitGame() {

		//Application.LoadLevel (mainMenu);
		SceneManager.LoadScene (mainMenu);
	}
}





